using ECommerce.Application.Features.Subcategories.Dtos;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly string httpContext;

        public SubcategoryService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContext = httpContextAccessor.HttpContext.Request.Headers["Language"].ToString();
        }
        public async Task<IList<SubcategoryDto>> GetAllSubcategoriesAsync()
        {
            IList<Subcategory> subcategories = await unitOfWork.GetRepository<Subcategory>().GetAllAsync(x => !x.IsDeleted);

            if (httpContext == CultureType.Turkish)
                return mapper.Map<SubcategoryDto, Subcategory>(subcategories,"NameEN");
            else
                return mapper.Map<SubcategoryDto, Subcategory>(subcategories,"NameTR");
        }
    }
}
