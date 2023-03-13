using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TableName { get; set; }
        public string Progress { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
    public class Error : Log
    {
        public string ExceptionMessage { get; set; }
        public string Code { get; set; }
    }
    public class Success : Log
    {
        public string Data { get; set; }
    }
    public class Info : Log
    {
        public string InfoMessage { get; set; }
    }

}
