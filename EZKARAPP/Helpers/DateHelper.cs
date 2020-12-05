using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EZKARAPP.Helpers
{
    public static class DateHelper
    {

        private static CultureInfo prsAF = new CultureInfo("prs-AF");
        private static CultureInfo enUs = new CultureInfo("en-US");

        private const string defaultFormat = "yyyy-MM-dd";

        /// <summary>
        /// Get today in persian calender format with default format (yyyy-MM-dd)
        /// </summary>
        /// <returns></returns>
        public static string ShamsiDateNow()
        {

            try
            {
                return DateTime.Now.ToString(defaultFormat, prsAF);

            }
            catch
            {
                return DateTime.Now.ToString(defaultFormat);
            }

        }
        /// <summary>
        /// Get today in persian calender format overloaded with format specified
        /// <param name="format">Format to return</param>
        /// </summary>
        /// <returns></returns>
        public static string ShamsiDateNow(string format)
        {

            try
            {
                return DateTime.Now.ToString(format, prsAF);

            }
            catch
            {
                return DateTime.Now.ToString(format);
            }

        }

        /// <summary>
        /// Get the date in persian calender format with default format (yyyy-MM-dd)
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <returns></returns>
        public static string ToShamsiDate(DateTime? date)
        {

            try
            {
                if (date == null)
                    return null;

                return Convert.ToDateTime(date).ToString(defaultFormat, prsAF);
            }
            catch
            {

                return DateTime.Now.ToString(defaultFormat);
            }
        }
        /// <summary>
        /// Get the date in persian calender format orloaded with format specified
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <param name="format">Format to return</param>
        /// <returns></returns>
        public static string ToShamsiDate(DateTime? date, string format)
        {

            try
            {
                if (date == null)
                    return null;

                return Convert.ToDateTime(date).ToString(format, prsAF);
            }
            catch
            {

                return DateTime.Now.ToString(format);
            }
        }

        /// <summary>
        /// Get the date in gregorian calender format with default format yyyy-MM-dd
        /// </summary>
        /// <param name="date">Format yyyy/MM/dd (1396-01-25)</param>
        /// <returns></returns>
        public static string ToGregorianDate(string date)
        {

            try
            {
                var value = DateTime.Parse(date, prsAF);
                enUs.DateTimeFormat.Calendar = new GregorianCalendar();
                return value.ToString(defaultFormat, enUs);
            }
            catch
            {

                return DateTime.Now.ToString(defaultFormat);
            }
        }
        /// <summary>
        /// Get the date in gregorian calender format  overload with return format specified
        /// </summary>
        /// <param name="date">Date to convert must be in this (1396-01-25) format</param>
        /// <param name="format">Format to return</param>
        /// <returns></returns>
        public static string ToGregorianDate(string date, string format)
        {

            try
            {
                var value = DateTime.Parse(date, prsAF);
                enUs.DateTimeFormat.Calendar = new GregorianCalendar();
                return value.ToString(format, enUs);
            }
            catch
            {

                return DateTime.Now.ToString(format);
            }
        }

    }
}