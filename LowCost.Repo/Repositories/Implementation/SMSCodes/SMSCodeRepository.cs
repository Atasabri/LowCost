using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.SMSCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.SMSCodes
{
    public class SMSCodeRepository : GenericRepository<SmsCode>, ISMSCodeRepository
    {
        public SMSCodeRepository(DB context)
            : base(context)
        {
        }
    }
}
