using System;
using JarlTime.Projections.GregorianProjection;
using DayOfWeek = JarlTime.Projections.GregorianProjection.DayOfWeek;

namespace JarlTime.Projections
{
	
	public class Gregorian:IProjection
	{
		private readonly Time time;
		private readonly TimeZone timezone;

		public Gregorian (ITimeContext context, int year, Month month, int day, int hour = 0, int minute = 0, int second = 0, int milliseconds = 0, TimeZone timezone = null)
		{
			if (timezone == null)
				timezone = context.Gmt ();
			this.timezone = timezone;
			//TODO: Validate input
			this.time = new DateTime (year, (int)month, day, hour, minute, second, milliseconds, System.DateTimeKind.Utc).ToTime (context);

		}

		internal Gregorian (Time time, TimeZone timezone)
		{
			this.time = time;
			if (timezone == null)
				timezone = time.Context.Gmt ();
			this.timezone = timezone;
		}

		public int Year {
			get{ return time.ToDateTime (timezone.ToTimeZoneInfo ()).Year; }
		}

		public Month Month {
			get{ return (Month)time.ToDateTime (timezone.ToTimeZoneInfo ()).Month - 1; }
		}

		public DayOfWeek DayOfWeek {
			get { return (DayOfWeek)((int)time.ToDateTime (timezone.ToTimeZoneInfo ()).DayOfWeek); }
		}

		public int Day {
			get {
				return time.ToDateTime (timezone.ToTimeZoneInfo ()).Day; 
			}
		}

		public int Hour {
			get{ return time.ToDateTime (timezone.ToTimeZoneInfo ()).Hour; }
		}

		public int Minute {
			get{ return time.ToDateTime (timezone.ToTimeZoneInfo ()).Minute; }
		}

		public int Second {
			get{ return time.ToDateTime (timezone.ToTimeZoneInfo ()).Second; }
		}

		public int Millisecond {
			get{ return time.ToDateTime (timezone.ToTimeZoneInfo ()).Millisecond; }
		}

		public override string ToString ()
		{
			return time.ToDateTime (timezone.ToTimeZoneInfo ()).ToString ();
		}


		public string ToString (string format)
		{
			return time.ToDateTime (timezone.ToTimeZoneInfo ()).ToString (format);//This will  not be like this in the future.
		}


		public Time Time {
			get {
				return time;
			}
		}

	}
}
