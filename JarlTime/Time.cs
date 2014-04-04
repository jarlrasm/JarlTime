using System;
using System.Collections.Generic;
namespace JarlTime
{
	public enum Timezone
	{
		UTC
	}
	public struct Time
	{
		private readonly DateTime datetime;

		private Time (DateTime datetime)
		{
			this.datetime=datetime;
		}

		public static Time Now ()
		{
			return new Time(DateTime.UtcNow);
		}
		private static IDictionary<ProjectionType,Func<Time,Timezone,IProjection>> projectionTypes=new Dictionary<ProjectionType,Func<Time,Timezone,IProjection>>()
		{
			{ProjectionType.Gregorian,(x,y)=>new GregorianProjection(x.datetime,y)}
		};
		public IProjection Projection(ProjectionType type=ProjectionType.Gregorian,Timezone timezone=Timezone.UTC)
		{
			return projectionTypes[type](this,timezone);
		}
	}
}

