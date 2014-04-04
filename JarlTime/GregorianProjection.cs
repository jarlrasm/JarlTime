using System;

namespace JarlTime
{
	
	public class GregorianProjection:IProjection
	{
		private readonly DateTime datetime;
		private readonly Timezone timezone;
		internal GregorianProjection (DateTime datetime, Timezone timezone)
		{
			this.datetime=datetime;
			this.timezone=timezone;
		}
	}
}
