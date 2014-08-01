#region License

// --------------------------------------------------
// Copyright © OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;

namespace JarlTime
{
    public class TimeZone
        //TODO: Does not really do much yet. It is supposed to implement IANA tz: http://www.iana.org/time-zones
    {
        private readonly string name;

        private TimeZone(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public static TimeZone Named(string name)
        {
            return new TimeZone(name);
        }


    }
}
