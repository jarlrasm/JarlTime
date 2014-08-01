using System;

namespace JarlTime
{
    public static class DateTimeExtensions
    {
        public static Time ToTime (this DateTime dateTime, ITimeContext context)
        {
            return new Time(new decimal((dateTime.ToUniversalTime() - DateTimeEpoch()).TotalSeconds), context);
        }

        public static DateTime DateTimeEpoch()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}