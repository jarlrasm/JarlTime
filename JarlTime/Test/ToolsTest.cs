using System;
using JarlTime.Projections;
using JarlTime;
using NUnit.Framework;

namespace Test
{
	[TestFixture]
	public class ToolsTest
	{
		[Test]
		public void BothEqual()
		{
			var time1 = new UnixEpoch (205956690, TimeContext.Default).Time;
			var time2 = new UnixEpoch (205956690, TimeContext.Default).Time;
			Assert.IsFalse(time1.IsAfter(time2));
			Assert.IsFalse(time2.IsAfter(time1));
		}
		[Test]
		public void FirstEarlier()
		{
			var time1=new UnixEpoch(205956690,TimeContext.Default).Time;
			var time2=new UnixEpoch(305956690,TimeContext.Default).Time;
			Assert.IsFalse(time1.IsAfter(time2));
			Assert.IsTrue(time2.IsAfter(time1));
		}
		[Test]
		public void LastEarlier()
		{
			var time1=new UnixEpoch(205956690,TimeContext.Default).Time;
			var time2=new UnixEpoch(105956690,TimeContext.Default).Time;
			Assert.IsTrue(time1.IsAfter(time2));
			Assert.IsFalse(time2.IsAfter(time1));
		}
		[Test]
		public void AndAddsInteval()
		{
			var interval = 10.Minutes().And(10.Seconds());
			Assert.AreEqual (610, interval.Seconds);
		}
	}
}

