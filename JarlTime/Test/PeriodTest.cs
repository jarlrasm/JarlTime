using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JarlTime;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class PeriodTest
    {
        [Test]
        public void TimeToReturnsPeriod()
        {
            var time = new Time(205956690, TimeContext.Default);
            var time2 = new Time(205956700, TimeContext.Default);
            var period = time.To(time2);
            Assert.AreEqual(205956690, period.Start.SecondsFromEpoch);
            Assert.AreEqual(205956700, period.End.SecondsFromEpoch);
            Assert.AreEqual(10, period.Length.Seconds);
            Assert.IsTrue(period.Contains(time));
            Assert.IsFalse(period.Contains(time2));
            Assert.IsTrue(period.Contains(time2.Remove(1.Seconds())));
            Assert.IsFalse(period.Contains(time.Remove(1.Seconds())));
            Assert.IsTrue(time.In(period));
            Assert.IsFalse(time2.In(period));
            Assert.IsTrue(time2.Remove(1.Seconds()).In(period));
            Assert.IsFalse(time.Remove(1.Seconds()).In(period));
        }
    }
}
