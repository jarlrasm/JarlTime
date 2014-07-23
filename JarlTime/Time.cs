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

		public override bool Equals (object obj)
		{
			if (obj is Time)
				return Equals ((Time)obj);
			return false;
		}

		public override int GetHashCode()
		{
			return secondsFromEpoch.GetHashCode();
		}

		public bool Equals(Time otherTime)
		{
			return secondsFromEpoch == otherTime.secondsFromEpoch;
		}

		public static bool operator ==(Time a, Time b)
		{
			if (System.Object.ReferenceEquals(a, b))
				return true;
				
			return a.Equals(b);
		}

		public static bool operator !=(Time a, Time b)
		{
			return !(a == b);
		}
		public static bool operator >(Time a, Time b)
		{
			return (a.secondsFromEpoch>b.secondsFromEpoch);
		}
		public static bool operator >=(Time a, Time b)
		{
			return (a.secondsFromEpoch>=b.secondsFromEpoch);
		}
		public static bool operator <(Time a, Time b)
		{
			return (a.secondsFromEpoch<b.secondsFromEpoch);
		}
		public static bool operator <=(Time a, Time b)
		{
			return (a.secondsFromEpoch<=b.secondsFromEpoch);
		}
	}
}

