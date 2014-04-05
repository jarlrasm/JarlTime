using System;

namespace JarlTime
{
	public static class TimeExtensions
	{
		public static Interval Interval(this Time time, Time othertime)
		{
			return new Interval(time.SecondsFromEpoch-othertime.SecondsFromEpoch);
		}
		public static Time Add(this Time time, Interval interval)
		{
			return new Time (time.SecondsFromEpoch + interval.Seconds);
		}
		public static Interval Seconds(this decimal number)
		{
			return new Interval (number);
		}
		public static Interval Seconds(this int number)
		{
			return new Interval (number);
		}
		public static Interval Minutes(this decimal number)
		{
			return (number*60).Seconds();
		}
		public static Interval Minutes(this int number)
		{
			return (number*60).Seconds();
		}
		public static Interval Hours(this decimal number)
		{
			return (number*60).Minutes();
		}
		public static Interval Hours(this int number)
		{
			return (number*60).Minutes();
		}
		public static Interval Days(this decimal number)
		{
			return (number*24).Hours();
		}
		public static Interval Days(this int number)
		{
			return (number*24).Hours();
		}

	}
}

