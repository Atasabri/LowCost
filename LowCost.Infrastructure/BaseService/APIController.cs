using LowCost.Infrastructure.Error_Handling;
using LowCost.Resources;
using LowCost.Resources.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace LowCost.Infrastructure.BaseService
{
    [APIErrorHandlingFilter]
    [Route("{culture}/api/[controller]")]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    [ApiController]
    public class APIController : ControllerBase
    {

    }
}
