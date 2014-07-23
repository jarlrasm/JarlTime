using System;
using NUnit.Framework;
using JarlTime.Projections;
using JarlTime;

namespace Test
{
	[TestFixture]
	public class OperatorTest
	{
		[Test]
		public void BothEqual()
		{
			var time1=new UnixEpoch(205956690,TimeContext.Default).Time;
			var time2=new UnixEpoch(205956690,TimeContext.Default).Time;
			Assert.AreEqual (time1, time2);
			Assert.IsTrue (time1 == time2);
			Assert.IsFalse (time1 != time2);
			Assert.IsFalse (time1 > time2);
			Assert.IsTrue (time1 >= time2);
			Assert.IsFalse (time1 < time2);
			Assert.IsTrue (time1 <= time2);
		}
		[Test]
		public void FirstEarlier()
		{
			var time1=new UnixEpoch(205956690,TimeContext.Default).Time;
			var time2=new UnixEpoch(305956690,TimeContext.Default).Time;
			Assert.AreNotEqual (time1, time2);
			Assert.IsFalse (time1 == time2);
			Assert.IsTrue (time1 != time2);
			Assert.IsFalse (time1 > time2);
			Assert.IsFalse (time1 >= time2);
			Assert.IsTrue (time1 < time2);
			Assert.IsTrue (time1 <= time2);
		}
		[Test]
		public void LastEarlier()
		{
			var time1=new UnixEpoch(205956690,TimeContext.Default).Time;
			var time2=new UnixEpoch(105956690,TimeContext.Default).Time;
			Assert.AreNotEqual (time1, time2);
			Assert.IsFalse (time1 == time2);
			Assert.IsTrue (time1 != time2);
			Assert.IsTrue (time1 > time2);
			Assert.IsTrue (time1 >= time2);
			Assert.IsFalse (time1 < time2);
			Assert.IsFalse (time1 <= time2);
		}
	}
}

