using System;

namespace JarlTime
{
	public struct Interval
	{
		private readonly decimal seconds;

		public decimal Seconds 
		{
			get
			{
				return seconds;
			}
		}

		public Interval (decimal seconds)
		{
			this.seconds = seconds;
		}
	}
}

