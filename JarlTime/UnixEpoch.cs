using System;

namespace JarlTime
{
	public class UnixEpoch:IProjection
	{
		private readonly Time time;

		internal UnixEpoch (Time time,Timezone timezone)
		{
			this.time = time;
		}

		public UnixEpoch(decimal seconds):this(new Time(seconds),null)
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

