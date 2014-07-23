using System;
using System.Collections.Generic;

namespace JarlTime
{
	public class TimeZone//TODO: Does not really do much yet. It is supposed to implement IANA tz: http://www.iana.org/time-zones
	{
		private readonly TimeZoneInfo internalTz;

		private TimeZone (System.TimeZoneInfo tz)
		{
			this.internalTz = tz;
		}

		public static TimeZone UTC ()
		{
			return new TimeZone (System.TimeZoneInfo.Utc);
		}

		public TimeZoneInfo ToTimeZoneInfo ()
		{
			return internalTz;
		}

		public  static TimeZone FromTimeZoneInfo (TimeZoneInfo tzInfo)
		{
			return new TimeZone (tzInfo);
			;
		}
	}
	
}
