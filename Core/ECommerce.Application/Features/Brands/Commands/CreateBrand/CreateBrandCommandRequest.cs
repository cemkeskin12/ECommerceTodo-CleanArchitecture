using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest
    {
        public string Name { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
