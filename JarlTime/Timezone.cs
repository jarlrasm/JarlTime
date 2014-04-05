using System;
using System.Collections.Generic;
namespace JarlTime
{
	public class Timezone
	{
		private readonly TimeZone internalTz;

		private Timezone()
		{

		}
		private Timezone(System.TimeZone tz)
		{
			this.internalTz = tz;
		}
		public static Timezone UTC()
		{
			return new Timezone ();
		}
		public static Timezone Local()
		{
			return new Timezone (TimeZone.CurrentTimeZone);
		}
		//TODO: Find a proper way of doing this without internal functions
		internal DateTime Translate(DateTime utc)
		{
			if (internalTz == null)
				return utc;
			return internalTz.ToLocalTime (utc);
		}
	}
	
}
