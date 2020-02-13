using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Extensions
{
    public static class DatetimeExtensions
    {
        public static string DateStringWithTime(this object value)
        {
            if (value == null)
                return "";
            else
                return Convert.ToDateTime(value).ToString("dd.MM.yyyy HH:mm");            
        }

        public static string DateStringWithoutTime(this object value)
        {
            if (value == null)
                return "";
            else
                return Convert.ToDateTime(value).ToString("dd.MM.yyyy");

        }
    }
}
