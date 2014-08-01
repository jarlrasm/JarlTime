using System;

namespace JarlTime.Projections
{
	
	public class Gregorian:IProjection
	{
		private readonly Time time;
		private readonly TimeZone timezone;

		public Gregorian (ITimeContext context, int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int milliseconds = 0, TimeZone timezone = null)
		{
			if (timezone == null)
				timezone = context.Gmt();
			this.timezone = timezone;
			//TODO: Validate input
			this.time = new DateTime (year, month, day, hour, minute, second, milliseconds, System.DateTimeKind.Utc).ToTime (context);

		}

		internal Gregorian (Time time, TimeZone timezone)
		{
			this.time = time;
			if (timezone == null)
				timezone = time.Context.Gmt();
			this.timezone = timezone;
		}

		public int Year {
			get{ return time.ToDateTime (timezone.ToTimeZoneInfo ()).Year; }
		}

		public GregorianMonth Month {
			get{ return (GregorianMonth)time.ToDateTime (timezone.ToTimeZoneInfo ()).Month-1; }
		}
        public GregorianDayOfWeek DayOfWeek
        {
            get { return (GregorianDayOfWeek)((int)time.ToDateTime(timezone.ToTimeZoneInfo()).DayOfWeek); }
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

    public enum GregorianMonth
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public enum GregorianDayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
