using System;

namespace JarlTime
{
	
	public class Gregorian:IProjection
	{
		private readonly DateTime datetime;
		public Gregorian(int year,int month,int day, int hour=0,int minute=0,int second=0, int milliseconds=0,Timezone timezone=null)
		{
			if (timezone == null)
				timezone = Timezone.UTC ();
			//TODO: Validate input
			this.datetime=timezone.Translate(new DateTime(year,month,day,hour,minute,second,milliseconds, System.DateTimeKind.Utc));
		}

		internal Gregorian (Time time, Timezone timezone)
		{
			var utctime = new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds (decimal.ToDouble (time.SecondsFromEpoch));
			this.datetime=timezone.Translate(utctime);
		}

		public int Year {
			get{return datetime.Year; }
		}
		public int Month {
			get{return datetime.Month; }
		}
		public int Day {
			get{return datetime.Day; }
		}
		public int Hour {
			get{return datetime.Hour; }
		}
		public int Minute {
			get{return datetime.Minute; }
		}
		public int Second {
			get{return datetime.Second; }
		}
		public int Millisecond {
			get{return datetime.Millisecond; }
		}

		public override string ToString ()
		{
			return datetime.ToString();
		}


		public string ToString (string format)
		{
			return datetime.ToString(format);//This will probably not be like this in the future.
		}

		public Time Time {
			get {
				return new Time(new decimal((datetime.ToUniversalTime()-new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc)).TotalSeconds));
			}
		}

	}
}
