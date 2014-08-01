﻿using System;
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
            var time = new Time(205956690, TimeContext.Default);
            var gregorian = time.Projection<Gregorian>(timezone);
            Assert.AreEqual("Etc/GMT", timezone.Name);
            Assert.AreEqual(TimeZoneInfo.Utc, timezone.ToTimeZoneInfo());
            Assert.AreEqual("11.07.1976 18:11:30", gregorian.ToString());
        }
        [Test]
        public void TimeZoneAtOsloIsAtOslo()
        {
            var timezone = Right.At("Europe/Oslo"); 
            var time=new Time(205956690, TimeContext.Default);
            var gregorian = time.Projection<Gregorian>(timezone);
            Assert.AreEqual("Europe/Oslo", timezone.Name);
            Assert.AreEqual(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"), timezone.ToTimeZoneInfo());
            Assert.AreEqual("11.07.1976 20:11:30", gregorian.ToString());
        }
    }
}