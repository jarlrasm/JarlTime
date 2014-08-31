using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace JarlTime
{
	public static class TimeZoneExtensions
	{

		public static TimeZoneInfo ToTimeZoneInfo (this TimeZone timeZone)
		{
			try 
            {
                //Windows
				return TimeZoneInfo.FindSystemTimeZoneById (TimeZoneExtensions.IanaNameToWindowsName (timeZone.Name));
			}
            catch
            {
                //IANA based timezones
				return TimeZoneInfo.FindSystemTimeZoneById (timeZone.Name);
			}
		}

		public static TimeZone ToTimeZone (this TimeZoneInfo tzInfo)
		{
			try
            {
                //Windows
				return TimeZone.Named (TimeZoneExtensions.WindowsNameToIanaName (tzInfo.Id));
			
            }
            catch
            {
                //IANA based timezones
				return TimeZone.Named (tzInfo.Id);
			}
		}

		private static IDictionary<Tuple<string, string>, string> timezoneNames;

		public static string IanaNameToWindowsName (string timezoneId)
		{
			return GetTimeZoneNameConverter ().First (x => x.Key.Item1 == timezoneId).Value;
		}

		public static string WindowsNameToIanaName (string timezoneId)
		{
			return GetTimeZoneNameConverter ().First (x => x.Value == timezoneId).Key.Item1;
		}

		private static IDictionary<Tuple<string,string>, string> GetTimeZoneNameConverter ()
		{
			if (timezoneNames != null)
				return timezoneNames;


			XDocument xmlDocument = ReadFromResource ("windowsZones.xml");
			timezoneNames = xmlDocument
		                .Root
		                .Element ("windowsZones")
		                .Element ("mapTimezones")
		                .Elements ("mapZone")
		                .ToDictionary (x => new Tuple<string,string> (x.Attribute ("type").Value, x.Attribute ("territory").Value), x => x.Attribute ("other").Value);
			return timezoneNames;
		}

		private static XDocument ReadFromResource (string filename)
		{
			using (Stream stream = typeof(TimeZoneExtensions).Assembly.
                		GetManifestResourceStream ("JarlTime.data." + filename)) {
				return XDocument.Load (stream);
			}
		}
	}
}