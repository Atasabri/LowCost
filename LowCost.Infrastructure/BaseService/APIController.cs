using LowCost.Infrastructure.Error_Handling;
using LowCost.Resources;
using LowCost.Resources.Localization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

    // Adding This 2 Attributes For Apply JWT Authentication Scheme Without Authorization
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    public class APIController : ControllerBase
    {

    }
}
