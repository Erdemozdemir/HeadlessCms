using System;
using System.Collections.Generic;
using System.Text;

namespace EdufaceCms.WebApplication.Helpers
{
    public static class NumericExtensions
    {
        public static int ToInt(this int? value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt(this object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
