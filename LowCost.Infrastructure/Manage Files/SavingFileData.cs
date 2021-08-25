using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.Manage_Files
{
    public class SavingFileData : FileBaseData
    {
        public IFormFile File { get; set; }
    }
}
