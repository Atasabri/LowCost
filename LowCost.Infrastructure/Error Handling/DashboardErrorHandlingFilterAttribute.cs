using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LowCost.Infrastructure.Error_Handling
{
    public class DashboardErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            if (context.HttpContext.Request.Method == "GET")
            {
                context.Result = new BadRequestResult();
            }
            else
            {
                context.ModelState.AddModelError("", context.Exception.Message);
            }
            //context.Result = new BadRequestResult();
        }
    }
}
