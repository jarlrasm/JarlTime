using System;

namespace JarlTime
{
	public static class IntervalExtensions
	{
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
		public static Interval And(this Interval inteval,Interval with)
		{
			return new Interval(inteval.Seconds+with.Seconds);
      }
      public static Time From(this Interval interval,Time origin)
      {
         return origin.Add(interval);
      }
	}
}

