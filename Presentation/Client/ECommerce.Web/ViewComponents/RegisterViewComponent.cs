using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.ViewComponents
{
    public class RegisterViewComponent : ViewComponent
    {

        public RegisterViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
