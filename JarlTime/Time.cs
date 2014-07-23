using System;
using System.Collections.Generic;
namespace JarlTime
{
	public struct Time
	{
		private readonly decimal secondsFromEpoch;
		private readonly ITimeContext context;

		public Time (decimal seconds,ITimeContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			this.context = context;
			this.secondsFromEpoch=seconds;
		}

		public ITimeContext Context
		{
			get{ return context;}
		}

		public decimal SecondsFromEpoch{get{ return secondsFromEpoch;}}

		public T Projection<T>(TimeZone timezone=null) where T:class,IProjection 
		{
			return context.GetProjection<T> (this, timezone);
		}
	}
}

