using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.BaseService
{
    [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizedAPIController : APIController
    {
    }
}
