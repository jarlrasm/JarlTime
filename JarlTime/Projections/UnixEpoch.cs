using System;

namespace JarlTime.Projections
{
	public class UnixEpoch:IProjection
	{
		private readonly Time time;

		internal UnixEpoch (Time time,TimeZone timezone)
		{
			this.time = time;
		}

		public UnixEpoch(decimal seconds,ITimeContext context):this(new Time(seconds,context),null)
		{
		}
		public decimal SecondsFromEpoch
		{
			get
			{
				return time.SecondsFromEpoch;
			}
		}
		public Time Time {
			get {
				return time;
			}
		}
	}
}

