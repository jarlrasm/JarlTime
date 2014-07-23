using System;

namespace JarlTime
{
	
	public class Gregorian:IProjection
	{
      private readonly Time time;
      private readonly Timezone timezone;
		public Gregorian(int year,int month,int day, int hour=0,int minute=0,int second=0, int milliseconds=0,Timezone timezone=null)
		{
			if (timezone == null)
				timezone = Timezone.UTC ();
         this.timezone = timezone;
			//TODO: Validate input
         time = new DateTime(year, month, day, hour, minute, second, milliseconds, System.DateTimeKind.Utc).ToTime();

		}

		internal Gregorian (Time time, Timezone timezone)
		{
         this.time = time;
         this.timezone = timezone;
		}

		public int Year 
      {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Year; }
		}
		public int Month 
      {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Month; }
		}
		public int Day {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Day; }
		}
		public int Hour {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Hour; }
		}
		public int Minute {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Minute; }
		}
		public int Second {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Second; }
		}
		public int Millisecond {
         get{return time.ToDateTime(timezone.ToTimeZoneInfo()).Millisecond; }
		}

		public override string ToString ()
		{
         return time.ToDateTime(timezone.ToTimeZoneInfo()).ToString();
		}


		public string ToString (string format)
		{
         return time.ToDateTime(timezone.ToTimeZoneInfo()).ToString(format);//This will  not be like this in the future.
		}


		public Time Time {
			get {
            return time;
			}
		}

	}
}
