using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.Helpers
{
    public static class DateTimeProvider
    {
        public static DateTime GetEgyptDateTime()
        {
            TimeZoneInfo newTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, newTimeZone);
        }
    }
}
