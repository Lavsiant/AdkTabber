using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model.Extensions
{
    public static class EnumStringExtension
    {
        public static string ToDescriptionString(this Enum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : val.ToString();
        }
    }
}
