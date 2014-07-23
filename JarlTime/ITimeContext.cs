using System;
using System.Collections.Generic;

namespace JarlTime
{
	public interface ITimeContext
	{
		Time Now();
		TimeZone Here();
		T GetProjection<T>(Time time,TimeZone tz) where T:class,IProjection;
	}
}

