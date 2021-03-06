﻿using System;
using System.Collections.Generic;
using JarlTime.Projections;

namespace JarlTime
{
	public class TimeContext:ITimeContext
	{
		public static void Register (ITimeContext context)
		{
			defaultContext = context;
		}

		public static ITimeContext Default {
			get {
				if (defaultContext == null)
					defaultContext = new TimeContext ();
				return defaultContext;
			}
		}

		static ITimeContext defaultContext;

		public Time Now ()
		{
			return new Time (new decimal ((DateTime.UtcNow - DateTimeExtensions.DateTimeEpoch ()).TotalSeconds), this);
		}

		public TimeZone Here ()
		{
			return TimeZoneInfo.Local.ToTimeZone ();
		}

		public TimeZone Gmt ()
		{
			return At ("Etc/GMT");
		}

		public TimeZone At (string name)
		{
			return TimeZone.Named (name);
		}


		public T GetProjection<T> (Time time, TimeZone tz) where T:class, IProjection
		{
			return projections [typeof(T)] (time, tz) as T;
		}

		private static IDictionary<Type,Func<Time,TimeZone,IProjection>> projections = new Dictionary<Type,Func<Time,TimeZone,IProjection>> () {
			{ typeof(Gregorian),(x, y) => new Gregorian (x, y) },
			{ typeof(UnixEpoch),(x, y) => new UnixEpoch (x, y) }
		};

		public void RegisterProjection<T> (Func<Time,TimeZone,IProjection> registration) where T:class, IProjection
		{
			projections [typeof(T)] = registration;
		}



	}
}

