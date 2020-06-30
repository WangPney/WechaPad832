namespace System
{
    public static class DatetimeExtension
    {
        private static readonly DateTime Date1970_1_1 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();

        /// <summary>
        /// 获取指定时间的时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static Int64 ToTimeStamp(this string date)
        {
            if (DateTime.TryParse(date, out DateTime dt))
            {
                return Unix(dt);
            }
            return Unix(Date1970_1_1);
        }

        /// <summary>
        /// 字符串时间转换为DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool TryParseToDateTime(this string date, out DateTime dt)
        {
            if (DateTime.TryParse(date, out dt))
            {
                return true;
            }
            return false;
        }

        public static bool TimestampToDateTime(this string timeStampSecondStr, out DateTime dateTime)
        {
            dateTime = DateTime.Now;
            if (long.TryParse(timeStampSecondStr, out long t))
            {
                dateTime = ToDateTime(t);
                return true;
            }
            return false;
        }

        public static bool TimestampToLocalDateTime(this string timeStampSecondStr, out DateTime dateTime)
        {
            dateTime = DateTime.Now;
            if (long.TryParse(timeStampSecondStr, out long t))
            {
                dateTime = ToDateTime(t);
                return true;
            }
            return false;
        }

        public static DateTime ToLocalDateTime(this string timeStampSecond)
        {
            return ToDateTime(timeStampSecond).ToLocalTime();
        }

        public static DateTime ToLocalDateTime(this long timeStampSecond)
        {
            return ToDateTime(timeStampSecond).ToLocalTime();
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStampSecond">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime ToDateTime(this string timeStampSecond)
        {
            return ToDateTime(long.Parse(timeStampSecond));
        }

        public static DateTime ToDateTime(this long timeStampSecond)
        {
            var ret = Date1970_1_1.AddSeconds(timeStampSecond);
            return ret;
        }

        public static DateTime MilSecToDateTime(long? timeStampMillSecond)
        {
            if (timeStampMillSecond == null)
            {
                return Date1970_1_1;
            }
            return Date1970_1_1.AddSeconds((long)(timeStampMillSecond / 1000)).ToLocalTime();
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>

        public static string NowDt(string format = "yyyy-MM-dd HH:mm:ss")
        {
            return DateTime.Now.ToString(format);
        }

        /// <summary>
        /// 获取当前时间的Unix时间戳格式
        /// </summary>
        /// <returns>Unix时间戳格式</returns>
        public static Int64 NowTimeStamp(bool millsec = false)
        {
            return Unix(DateTime.Now.ToUniversalTime(), millsec);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <param name = "millsec" >精确到毫秒</param>
        /// <returns>Unix时间戳格式</returns>
        public static Int64 Unix(this DateTime time, bool millsec = false)
        {
            TimeSpan ts = time.ToUniversalTime() - Date1970_1_1;
            return millsec ? (Int64)ts.TotalMilliseconds : (Int64)ts.TotalSeconds;
        }

        public static Int64 Unix(this DateTime end, DateTime start, bool millsec = false)
        {
            TimeSpan ts = end - start;
            return millsec ? (Int64)ts.TotalMilliseconds : (Int64)ts.TotalSeconds;
        }
    }
}
