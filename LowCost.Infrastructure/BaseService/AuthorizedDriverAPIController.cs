using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.BaseService
{
    [Authorize(Roles = Constants.DriverRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizedDriverAPIController : APIController
    {
    }
}
