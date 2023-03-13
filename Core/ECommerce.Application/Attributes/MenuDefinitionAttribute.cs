using ECommerce.Domain.Enums;

namespace ECommerce.Application.Attributes
{
    public class MenuDefinitionAttribute : Attribute
    {
        //public string Menu { get; set; }
        //public string Definition { get; set; }
        public ActionType ActionType { get; set; }
    }
}
