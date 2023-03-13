using ECommerce.Application.Features.Brands.Dtos;
using ECommerce.Application.Features.Subcategories.Dtos;
using ECommerce.Domain.Entities;
using Newtonsoft.Json;

namespace ECommerce.Application.Features.Products.Dtos
{
    public class GetProductByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public BrandDto Brand { get; set; }
        public SubcategoryDto Subcategory { get; set; }
        [JsonIgnore]
        public ICollection<AttributeValue> AttributeValues { get; set; }
        [JsonIgnore]
        public ICollection<Rating> Ratings { get; set; }
        //public RatingAddDto RatingAddDto { get; set; }
    }
}
