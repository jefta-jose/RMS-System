using System;
using System.Globalization;

namespace api.Helpers
{
    public static class DateTimeExtensions
    {
        public static int DiffWeekOfYear(this DateTime dt1, DateTime dt2)
        {
            // Ensure dt1 is always the earlier date
            if (dt1 > dt2)
                (dt1, dt2) = (dt2, dt1);

            // Get week numbers
            var calendar = CultureInfo.CurrentCulture.Calendar;
            int week1 = calendar.GetWeekOfYear(dt1, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int week2 = calendar.GetWeekOfYear(dt2, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

            // Check if the years are different
            if (dt1.Year == dt2.Year)
            {
                return Math.Abs(week2 - week1); // Same year: simple subtraction
            }
            else
            {
                // Get the last week number of the first year
                int lastWeekOfYear1 = calendar.GetWeekOfYear(new DateTime(dt1.Year, 12, 31), CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                // Compute total weeks across years
                return (lastWeekOfYear1 - week1) + week2;
            }
        }

        //The purpose of this method is to determine the start of the current week for a given DateTime object.
        public static DateTime GetStartOfWeek(this DateTime dt)
        {
            DateTime newDateTime = dt.Subtract(TimeSpan.FromDays((int)dt.DayOfWeek));
            return new DateTime(newDateTime.Year, newDateTime.Month, newDateTime.Day, 0, 0, 0, 0, DateTimeKind.Utc);
        }

        //The purpose of this method is to determine the end of the current week for a given DateTime object.
        public static DateTime GetEndOfWeek(this DateTime dt)
        {
            DateTime newDateTIme = dt.GetStartOfWeek().AddDays(6);
            return new DateTime(newDateTIme.Year, newDateTIme.Month, newDateTIme.Day, 23, 59, 59, 999, DateTimeKind.Utc);
        }

        //Get the currents' week monday
        public static DateTime GetCurrentWeekMonday(this DateTime dt)
        {
            int days = dt.DayOfWeek - DayOfWeek.Monday;
            if(days < 0)
            {
                days += 7;
            }

            return dt.AddDays(-days).Date;
        }

        public static DateTime GetDateTimeInEst(DateTime utcDateTime)
        {
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, estTimeZone);
        }

        public static DateTime GetThisWeekMonday()
        {
            var currentDateTime = DateTime.Now;

            return currentDateTime.AddDays(DayOfWeek.Monday - currentDateTime.DayOfWeek);
        }

        public static DateTime GetStartOfThisWeek()
        {
            var currentDateTime = DateTime.Now;

            return currentDateTime.AddDays(DayOfWeek.Sunday - currentDateTime.DayOfWeek);
        }
    }
}
