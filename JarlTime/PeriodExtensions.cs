using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JarlTime
{
    public static class PeriodExtensions
    {
        public static bool Contains(this Period period,Time time)
        {
            return period.Start<=time&&period.End>time;
        }
    }
}
