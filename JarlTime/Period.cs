using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JarlTime
{
    public class Period
    {
        private readonly Time start;
        private readonly Interval length;
        public Period(Time start, Interval length)
        {
            this.start = start;
            this.length = length;
        }
        public Period(Time start, Time end)
        {
            this.start = start;
            this.length = end.Interval(start);
        }


        public Time Start
        {
            get { return start; }
        }

        public Interval Length
        {
            get { return length; }
        }
    }
}
