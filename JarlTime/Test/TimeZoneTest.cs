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
        public void TimeZoneGmtIsGmt ()
        {
            var timezone = Right.AtGmt;
            var time = new Time (1409473135, TimeContext.Default);
            var gregorian = time.Projection<Gregorian> (timezone);
            Assert.AreEqual ("Etc/GMT", timezone.Name);
            Assert.AreEqual (TimeZoneInfo.Utc, timezone.ToTimeZoneInfo ());
            Assert.AreEqual ("31.08.2014 08:18:55", gregorian.ToString ("dd.MM.yyyy hh:mm:ss"));
        }

        [Test]
        public void TimeZoneAtOsloIsAtOslo ()
        {
            var timezone = Right.At ("Europe/Oslo"); 
            var time = new Time (1409473135, TimeContext.Default);
            var gregorian = time.Projection<Gregorian> (timezone);
            var zoneinfo = timezone.ToTimeZoneInfo ();
            TimeZoneInfo target;
            try {
                target = TimeZoneInfo.FindSystemTimeZoneById ("W. Europe Standard Time");
            } catch {
                target = TimeZoneInfo.FindSystemTimeZoneById ("Europe/Oslo");
            }
            Assert.AreEqual ("Europe/Oslo", timezone.Name);
            Assert.AreEqual (target, zoneinfo);
            Assert.AreEqual ("31.08.2014 10:18:55", gregorian.ToString ("dd.MM.yyyy hh:mm:ss"));
        }
    }
}
