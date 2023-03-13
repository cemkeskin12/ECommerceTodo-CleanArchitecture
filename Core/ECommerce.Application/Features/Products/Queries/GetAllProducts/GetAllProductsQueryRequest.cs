using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
