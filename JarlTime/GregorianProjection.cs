using System;

namespace JarlTime
{
	
	public class GregorianProjection:IProjection
	{
		private readonly DateTime datetime;
		private readonly Timezone? timezone;
		internal GregorianProjection (DateTime datetime, Timezone? timezone=null)
		{
			this.datetime=datetime;
			this.timezone=timezone;
		}
		public override string ToString ()
		{
			switch (timezone) {
			case Timezone.UTC:
				return datetime.ToString();
			}
			return datetime.ToLocalTime().ToString();
		}
	}
}
