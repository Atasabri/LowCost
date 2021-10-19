using LowCost.Infrastructure.Error_Handling;
using LowCost.Infrastructure.Helpers;
using LowCost.Resources.Localization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.BaseService
{
    [APIErrorHandlingFilter]
    [Route("{culture}/api/[controller]")]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    [ApiController]
    [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizedAPIController : ControllerBase
    {
    }
}
