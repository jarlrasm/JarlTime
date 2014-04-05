using System;
using System.Collections.Generic;
namespace JarlTime
{
	public struct Time
	{
		private readonly decimal secondsFromEpoch;

		public Time (decimal seconds)
		{
			this.secondsFromEpoch=seconds;
		}

		public static Time Now ()
		{
			return new Time(new decimal((DateTime.UtcNow-new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc)).TotalSeconds));
		}

		public decimal SecondsFromEpoch{get{ return secondsFromEpoch;}}

		private static IDictionary<Type,Func<Time,Timezone,IProjection>> constructors=new Dictionary<Type,Func<Time,Timezone,IProjection>>()
		{
			{typeof(Gregorian),(x,y)=>new Gregorian(x,y)},
			{typeof(UnixEpoch),(x,y)=>new UnixEpoch(x,y)}
		};
		public T Projection<T>(Timezone timezone=null) where T:class,IProjection 
		{
			if (timezone == null)
				timezone = Timezone.UTC ();
			return constructors[typeof(T)](this,timezone) as T;
		}
	}
}

