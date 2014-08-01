using System;

namespace JarlTime
{
	public static class Right//Syntactic sugar
	{
		public static Time Now
		{
			get{return TimeContext.Default.Now();}
		}
		public static TimeZone Here
		{
			get{return TimeContext.Default.Here();}
		}
        public static TimeZone At(string timezone)
        {
            return TimeContext.Default.At(timezone);
        }
        public static TimeZone AtGmt
        {
            get { return TimeContext.Default.Gmt(); }
        }
	}
}

