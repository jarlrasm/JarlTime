using System;
using System.Collections.Generic;
namespace JarlTime
{
	public class Timezone
	{
        private readonly TimeZoneInfo internalTz;

		private Timezone(System.TimeZoneInfo tz)
		{
			this.internalTz = tz;
		}
		public static Timezone UTC()
		{
         return new Timezone ( System.TimeZoneInfo.Utc);
		}
		public static Timezone Local()
		{
         return new Timezone (TimeZoneInfo.Local);
		}
		public decimal Translate(decimal utcSecondsFromEpoch)
		{
            //Really hackish
         var time = new Time(utcSecondsFromEpoch).ToDateTime(internalTz);
            return new decimal((time-new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc)).TotalSeconds);
		}
         public TimeZoneInfo ToTimeZoneInfo()
         {
            return internalTz;
         }
	}
	
}
