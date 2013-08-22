using System;
using System.Collections.Generic;
using System.Text;

namespace entCMS.Common
{
    public class ParameterFilter
    {
        // Methods
        public static bool GetBool(object obj)
        {
            bool result;
            if (((obj == null) || Convert.IsDBNull(obj)) || string.IsNullOrEmpty(obj.ToString()))
            {
                return false;
            }
            return ((obj.ToString() == "1") || (bool.TryParse(obj.ToString(), out result) && result));
        }
        public static string GetDate(object date)
        {
            return GetDate(date, "yyyy-MM-dd");
        }

        public static string GetDate(object date, string format)
        {
            DateTime dt;
            string defaultValue = string.Empty;
            if (((date != null) && (date.ToString().Length != 0)) && DateTime.TryParse(date.ToString(), out dt))
            {
                if (((((dt == DateTime.MinValue) || (dt.ToString("yyyy-MM-dd") == "9999-12-31")) || ((dt == DateTime.MaxValue) || (dt.ToString("yyyy-MM-dd") == "1900-01-01"))) || (dt.ToString("yyyy-MM-dd") == "0000-00-00")) || (dt.ToString("yyyy-MM-dd") == "0001-01-01"))
                {
                    return defaultValue;
                }
                return dt.ToString(format);
            }
            return defaultValue;
        }

        public static DateTime GetDateTime(object obj, DateTime defaultTime)
        {
            DateTime result;
            DateTime defaultValue = defaultTime;
            if (((obj != null) && (obj.ToString() != "")) && (DateTime.TryParse(obj.ToString(), out result) && ((result.Date != DateTime.MaxValue.Date) && (result.Date != DateTime.MinValue.Date))))
            {
                return result;
            }
            return defaultValue;
        }

        public static decimal GetDecimal(object obj)
        {
            decimal defaultValue = 0M;
            if ((obj == null) || (obj.ToString().Length == 0))
            {
                return defaultValue;
            }
            return GetDecimal(obj, defaultValue);
        }

        public static decimal GetDecimal(object obj, decimal defaultValue)
        {
            decimal result;
            if ((obj != null) && decimal.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static float GetFloat(object obj)
        {
            float defaultValue = -1f;
            if (((obj == null) || Convert.IsDBNull(obj)) || string.IsNullOrEmpty(obj.ToString()))
            {
                return defaultValue;
            }
            return GetFloat(obj, defaultValue);
        }

        public static float GetFloat(object obj, float defaultValue)
        {
            float result;
            if (float.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static int GetInt(object obj)
        {
            int result;
            if (((obj != null) && (obj.ToString().Trim().Length != 0)) && int.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return -1;
        }

        public static int GetInt(object obj, int defaultValue)
        {
            int result;
            if (((obj != null) && (obj.ToString().Length != 0)) && int.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static int? GetInt(object obj, int? defaultValue)
        {
            int result;
            if (((obj != null) && (obj.ToString().Length != 0)) && int.TryParse(obj.ToString(), out result))
            {
                return new int?(result);
            }
            return defaultValue;
        }

        public static string GetMonth(object date)
        {
            return GetDate(date, "yyyy年MM月");
        }

        public static string GetNumberDot2(object dnum)
        {
            if (dnum == null)
            {
                return "0.00";
            }
            try
            {
                return Math.Round(decimal.Parse(dnum.ToString()), 2).ToString();
            }
            catch (Exception)
            {
                return "0.00";
            }
        }

        public static string GetString(object obj)
        {
            if ((obj == null) || (obj.ToString().Length == 0))
            {
                return string.Empty;
            }
            return obj.ToString();
        }

        public static string GetString(object obj, string defaultValue)
        {
            if ((obj == null) || (obj.ToString().Length == 0))
            {
                return defaultValue;
            }
            return obj.ToString();
        }

        public static DateTime GetTime(object obj)
        {
            DateTime defaultValue = DateTime.MaxValue;
            if ((obj == null) || (obj.ToString() == ""))
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
