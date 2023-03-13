using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ECommerce.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider modelMetadata;

        public ExceptionFilter(IModelMetadataProvider modelMetadata)
        {
            this.modelMetadata = modelMetadata;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var errorModel = new ErrorViewModel();
            ViewResult result;
            switch (context.Exception)
            {

                case UnauthorizedAccessException:
                    errorModel.Message =
                        $"Üzgünüz, işleminiz sırasında beklenmedik bir veritabanı hatası oluştu. Sorunu en kısa sürede çözeceğiz.";
                    errorModel.Detail = context.Exception.Message;
                    result = new ViewResult { ViewName = "Error" };
                    result.StatusCode = 401;
                    //_logger.LogError(context.Exception, context.Exception.Message);
                    break;
                case NullReferenceException:
                    errorModel.Message =
                        $"Üzgünüz, işleminiz sırasında beklenmedik bir null veriye rastlandı. Sorunu en kısa sürede çözeceğiz.";
                    errorModel.Detail = context.Exception.Message;
                    result = new ViewResult { ViewName = "Error" };
                    result.StatusCode = 404;
                    //_logger.LogError(context.Exception, context.Exception.Message);
                    break;
                default:
                    errorModel.Message =
                        $"Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu.";
                    result = new ViewResult { ViewName = "Error" };
                    result.StatusCode = 500;
                    //_logger.LogError(context.Exception, "Bu benim log hata mesajım!");
                    break;
            }
            result.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState)
            {
                { "errorModel", errorModel }
            };
            context.Result = result;
        }
    }
}
