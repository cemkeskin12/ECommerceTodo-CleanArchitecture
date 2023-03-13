using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using ECommerce.Application.Features.Products.Queries.GetProductById;
using ECommerce.Application.Interfaces.Mails;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Client.Helpers;
using ECommerce.Client.Models;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ECommerce.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMailService mailService;

        public HomeController(IMediator mediator, IUnitOfWork unitOfWork, IMailService mailService)
        {
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;
            this.mailService = mailService;
        }

        public async Task<IActionResult> Index(int pageSize)
        {
            //currentPage = 1;
            //pageSize = 2;
            var list = await mediator.Send(new GetAllProductsQueryRequest());
            //await mailService.SendMessageAsync("cemkeskin12@gmail.com", "Ha bu yemdur", "<strong>Deneme Maili 12 34 !@</strong>","Bu nedir ben de bilmez");
            return View(list);
        }
        public async Task<IActionResult> Detail(Guid productId)
        {
            var product = await mediator.Send(new GetProductByIdQueryRequest() { Id = productId});
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingAddDto ratingAddDto)
        {
            Guid userId = Guid.Parse("cb94223b-ccb8-4f2f-93d7-0df96a7f065c");
            Guid productId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69");
            Rating rating = new()
            {
                Rate = ratingAddDto.Rate,
                Comment = ratingAddDto.Comment,
                ProductId = productId,
                UserId = userId
            };
            await unitOfWork.GetRepository<Rating>().AddAsync(rating);
            await unitOfWork.SaveAsync();
            return RedirectToAction("Detail", "Home", new { productId = productId});
        }
        public async Task<IActionResult> AddToCart(Guid productId)
        {
            List<Cart> cartList = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            var product = await unitOfWork.GetRepository<Product>().GetAsync(x => x.Id == productId);
            if (cartList == null)
            {
                List<Cart> cart = new()
                {
                    new Cart { Product = product, Quantity = 1 }
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = IsExist(productId);
                if(index != -1)
                {
                    cartList[index].Quantity++;
                }
                else
                {
                    cartList.Add(new Cart { Product = product, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartList);
            }
            return RedirectToAction("Index");


        }
        public IActionResult Remove(Guid productId)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = IsExist(productId);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private int IsExist(Guid id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}