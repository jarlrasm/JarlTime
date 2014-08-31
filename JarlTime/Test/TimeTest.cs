using System;
using JarlTime.Projections.GregorianProjection;
using NUnit.Framework;
using JarlTime;
using JarlTime.Projections;
using DayOfWeek = JarlTime.Projections.GregorianProjection.DayOfWeek;

namespace Test
{
	[TestFixture]
	public class TimeTest
	{
		[Test]
		public void UnixEpochCreatesTime ()
		{
			var time = new UnixEpoch (205956690, TimeContext.Default).Time;
			Assert.AreEqual (205956690, time.SecondsFromEpoch);
		}

		[Test]
		public void GregorianPrintsNicely ()
		{
			var time = new Time (205956690, TimeContext.Default);
			string result = time.Projection<Gregorian> ().ToString ("yyyy MM dd");
			Assert.AreEqual ("1976 07 11", result.ToString ());
		}

		[Test]
		public void GregorianYearIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (1976, time.Projection<Gregorian> ().Year);
		}

		[Test]
		public void GregorianMonthIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (Month.July, time.Projection<Gregorian> ().Month);
		}

		[Test]
		public void GregorianDayOfWeekIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (DayOfWeek.Sunday, time.Projection<Gregorian> ().DayOfWeek);
		}

		[Test]
		public void GregorianDayIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (11, time.Projection<Gregorian> ().Day);
		}

		[Test]
		public void GregorianHourIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (18, time.Projection<Gregorian> ().Hour);
		}

		[Test]
		public void GregorianMinuteIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (11, time.Projection<Gregorian> ().Minute);
		}

		[Test]
		public void GregorianSecondIsRight ()
		{
			var time = new Time (205956690, TimeContext.Default);
			Assert.AreEqual (30, time.Projection<Gregorian> ().Second);
		}

		[Test]
		public void NowIsApproximatelyTheSameWithTimeAndDateTime ()
		{
			var time = Right.Now;
			var datetime = DateTime.UtcNow;
			var time2 = new Gregorian (TimeContext.Default, datetime.Year, (Month)datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond).Time;
			Assert.IsTrue (time.Interval (time2).Seconds < 1);
			Assert.IsTrue (time.Interval (time2).Seconds > -1);
		}

		[Test]
		public void AddingSecondsAddsSeconds ()
		{
			var time = Right.Now;
			var newtime = time.Add (1.Seconds ());
			Assert.AreEqual (-1, time.Interval (newtime).Seconds);
		}

		[Test]
		public void AddingDecimalSecondsAlsoAddsSeconds ()
		{
			var time = Right.Now;
			var newtime = time.Add (1.2m.Seconds ());
			Assert.AreEqual (-1.2, time.Interval (newtime).Seconds);
		}

		[Test]
		public void AddingMinutesAddsMinutes ()
		{
			var time = Right.Now;
			var newtime = time.Add (1.Minutes ());
			Assert.AreEqual (-60, time.Interval (newtime).Seconds);
		}

		[Test]
		public void AddingHoursAddsHours ()
		{
			var time = Right.Now;
			var newtime = time.Add (1.Hours ());
			Assert.AreEqual (-3600, time.Interval (newtime).Seconds);
		}

		[Test]
		public void AddingDaysAddsDays ()
		{
			var time = Right.Now;
			var newtime = time.Add (1.Days ());
			Assert.AreEqual (-86400, time.Interval (newtime).Seconds);
		}

		[Test]
		public void RemovingSecondsRemovesSeconds ()
		{
			var time = Right.Now;
			var newtime = time.Remove (1.Seconds ());
			Assert.AreEqual (1, time.Interval (newtime).Seconds);
		}
	}
}

