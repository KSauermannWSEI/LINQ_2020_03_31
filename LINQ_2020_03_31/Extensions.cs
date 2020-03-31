using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_2020_03_31
{
    public static class Extensions
    {
        public static int ToInt(this object val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return int.MinValue;
            }            
        }
        public static string Left(this string val, int digits)
        {
            return val.Substring(0, digits);
        }
    }
}
