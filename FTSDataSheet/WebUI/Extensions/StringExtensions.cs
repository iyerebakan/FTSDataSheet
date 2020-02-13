using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Extensions
{
    public static class StringExtensions
    {
        public static string UnDash(this object value)
        {
            return ((value as string) ?? string.Empty).UnDash();
        }

        public static string UnDash(this string value)
        {
            return (value.ToLower() ?? string.Empty);
        }

        public static string ChangeValue(this string value)
        {
            value = value.ToLower();
            if (value == "user")
                value = "userlist";
            else if (value == "customeruser")
                value = "customeruserlist";
            else if (value == "customer")
                value = "customerlist";
            else if (value == "datasheet")
                value = "datasheetlist";

            return value;
        }
    }
}
