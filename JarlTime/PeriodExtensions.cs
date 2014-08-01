using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JarlTime
{
    public static class PeriodExtensions
    {
        public static Time End(this Period period)
        {
            return period.Start.Add(period.Length);
        }
        public static bool Contains(this Period period,Time time)
        {
            return period.Start<=time&&period.End()>time;
        }
    }
}
