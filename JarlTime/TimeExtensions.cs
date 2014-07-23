using System;

namespace JarlTime
{
	public static class TimeExtensions
	{
		public static Interval Interval (this Time time, Time othertime)
		{
			return new Interval (time.SecondsFromEpoch - othertime.SecondsFromEpoch);
		}

		public static Time Add (this Time time, Interval interval)
		{
			return new Time (time.SecondsFromEpoch + interval.Seconds, time.Context);
		}

		public static bool IsBefore (this Time time, Time otherTime)
		{
			return time < otherTime;
		}

		public static bool IsAfter (this Time time, Time otherTime)
		{
			return time > otherTime;
		}

		public static DateTime ToDateTime (this Time fromtime, TimeZoneInfo timezone)
		{
			return TimeZoneInfo.ConvertTime (new DateTime (1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                                         .AddSeconds ((double)fromtime.SecondsFromEpoch), TimeZoneInfo.Utc, timezone);
		}

		public static Time ToTime (this DateTime dateTime, ITimeContext context)
		{
			return new Time (new decimal ((dateTime.ToUniversalTime () - new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds), context);
		}
	}
}

