using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
    public class FluentValidationErrors : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
