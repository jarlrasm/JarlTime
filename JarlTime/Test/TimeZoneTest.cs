using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JarlTime;
using JarlTime.Projections;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class TimeZoneTest
    {
        [Test]
        public void TimeZoneGmtIsGmt()
        {
            var timezone = Right.AtGmt;
            Assert.AreEqual("Etc/GMT", timezone.Name);
            Assert.AreEqual(TimeZoneInfo.Utc, timezone.ToTimeZoneInfo());
        }
        [Test]
        public void TimeZoneAtOsloIsAtOslo()
        {
            var timezone = Right.At("Europe/Oslo");
            var time = Right.Now;
            var datetime = time.ToDateTime(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
            var gregorian = time.Projection<Gregorian>(timezone);
            Assert.AreEqual(datetime.ToString(),gregorian.ToString());
            Assert.AreEqual("Europe/Oslo", timezone.Name);
            Assert.AreEqual(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"), timezone.ToTimeZoneInfo());
        }
    }
}
