
namespace ET
{
    public static partial class Util
    {
        private static readonly string[] Number100 =
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
            "20", "21", "22", "23", "24", "25", "26", "27", "28", "29",
            "30", "31", "32", "33", "34", "35", "36", "37", "38", "39",
            "40", "41", "42", "43", "44", "45", "46", "47", "48", "49",
            "50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
            "60", "61", "62", "63", "64", "65", "66", "67", "68", "69",
            "70", "71", "72", "73", "74", "75", "76", "77", "78", "79",
            "80", "81", "82", "83", "84", "85", "86", "87", "88", "89",
            "90", "91", "92", "93", "94", "95", "96", "97", "98", "99",
            "100", "101", "102", "103", "104", "105", "106", "107", "108", "109",
        };

        public static string String(this int value)
        {
            if (value < 0 || value >= Number100.Length)
            {
                return value.ToString();
            }

            return Number100[value];
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        
        /// <summary>
        /// 字符串转换到int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this string value, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            int.TryParse(value, out var result);
            return result;
        }
        
        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            byte.TryParse(value, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转换到long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            long.TryParse(value, out var result);
            return result;
        }
        
        public static double ToDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            
            double.TryParse(value, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转换到float
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ToFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            float.TryParse(value, out var result);
            return result;
        }
        
        /// <summary>
        /// 字符串转bool值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.ToLower().Equals("true");
        }
    }
}