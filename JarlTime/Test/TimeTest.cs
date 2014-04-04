using System;
using NUnit.Framework;
using JarlTime;

namespace Test
{
	[TestFixture]
	public class TimeTest
	{
		[Test]
		public void GregorianProjectionToString()
		{
			var time=Time.Now();
			string result=time.Local().ToString();
		}
	}
}

