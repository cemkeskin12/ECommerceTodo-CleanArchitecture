using System.Globalization;

namespace ECommerce.WebApi.Middlewares
{
    public class CultureMiddleware
    {

        private readonly RequestDelegate next;
        public CultureMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var culture = httpContext.Request.Headers["Language"].ToString();
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            else
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

            await next(httpContext);
        }
    }
}
