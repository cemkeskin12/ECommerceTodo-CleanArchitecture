using ECommerce.Application.Features.Brands.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
        public IFormFileCollection? Photos { get; set; }
        //public Guid SubcategoryId { get; set; }
        //public IList<BrandDto> Brands { get; set; }
        //public IList<SubcategoryDto> Subcategories { get; set; }
    }
}
