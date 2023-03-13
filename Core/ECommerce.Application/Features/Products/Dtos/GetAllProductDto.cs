using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Features.Images.Dtos;
using ECommerce.Application.Features.Subcategories.Dtos;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Dtos
{
    public class GetAllProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public BrandDto Brand { get; set; }
        public SubcategoryDto Subcategory { get; set; }
        public ICollection<ImageDto> Images { get; set; }
    }
}
