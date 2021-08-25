using LowCost.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LowCost.Infrastructure.Error_Handling
{
    public class APIErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        private string lang { get { return CultureInfo.CurrentCulture.Name; } }
        public override void OnException(ExceptionContext context)
        {
            var response = new ExceptionResponse()
            {
                Error = lang == "ar" ? "حدث خطأ ما غير معروف" : "An unknown failure has occurred.",
                ExceptionMessage = context.Exception?.Message,
                InnerMessage = context.Exception?.InnerException?.Message,
            };
            context.Result = new BadRequestObjectResult(response);

            context.ExceptionHandled = true;
        }
    }
}
