using System;

namespace JarlTime
{
	public static class TimeExtensions
	{
		public static Interval Interval (this Time time, Time othertime)//This will give negative if other is later. Is this good?
		{
			return new Interval (time.SecondsFromEpoch - othertime.SecondsFromEpoch);
		}

		public static Period To (this Time start, Time end)
		{
			return new Period (start, end);
		}

		public static bool In (this Time time, Period period)
		{
			return period.Contains (time);
		}

		public static Time Add (this Time time, Interval interval)
		{
			return new Time (time.SecondsFromEpoch + interval.Seconds, time.Context);
		}

		public static Time Remove (this Time time, Interval interval)
		{
			return new Time (time.SecondsFromEpoch - interval.Seconds, time.Context);
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
			return TimeZoneInfo.ConvertTime (DateTimeExtensions.DateTimeEpoch ()
                                         .AddSeconds ((double)fromtime.SecondsFromEpoch), TimeZoneInfo.Utc, timezone);
		}
	}
}

