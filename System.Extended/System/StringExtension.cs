using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace System
{
    public static class StringExtension
    {
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
        public static string ToHexString(this short[] data, int start = 0, int len = 0)
        {
            if (data == null) { return ""; }
            StringBuilder sb = new StringBuilder();
            if (start < 0 || start > data.Length)
            {
                start = 0;
            }
            if (len <= 0 || start + len >= data.Length)
            {
                len = data.Length - start;
            }
            for (int i = start; i < start + len; ++i)
            {
                sb.Append(data[i].ToString("X"));
            }
            return sb.ToString().Trim();
        }

        public static string ToHexString(this byte b)
        {
            return ToHexString(new byte[] { b});
        }

        public static string ToHexString(this byte[] data, bool upperCase = false, int start = 0, int len = 0)
        {
            return ToHexString(data, " ", upperCase, start, len);
        }

        public static string ToHexString(this byte[] data, string sp,bool upperCase=false, int start = 0, int len = 0)
        {
            if (data == null) { return ""; }
            try
            {
                if (data.Length == 0)
                {
                    return "";
                }
                StringBuilder sb = new StringBuilder();
                if (start < 0 || start > data.Length)
                {
                    start = 0;
                }
                if (len <= 0 || start + len >= data.Length)
                {
                    len = data.Length - start;
                }
                for (int i = start; i < start + len; ++i)
                {
                    sb.Append(data[i].ToString($"{(upperCase ? "X2" : "x2")}"));
                    if (i < start + len - 1)
                    {
                        sb.Append(sp);
                    }
                }
                return sb.ToString().Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static byte[] HexToBytes(this string hexString)
        {
            return ToByteArray(hexString, 16, 2);
        }

        public static byte[] ToDefaultBytes(this string data)
        {
            if (data == null) { return null; }
            return Encoding.Default.GetBytes(data);
        }

        public static byte[] ToUtf8Bytes(this string data, int totalLen, char paddingChar)
        {
            if (data == null) { return null; }
            return ToUtf8Bytes(data.PadRight(totalLen, paddingChar));
        }

        public static byte[] ToUtf8Bytes(this string data)
        {
            if (data == null) { return null; }
            return Encoding.UTF8.GetBytes(data);
        }

        public static byte[] ToAsciiBytes(this string data, int totalLen, char paddingChar)
        {
            if (data == null) { return null; }
            return ToAsciiBytes(data.PadRight(totalLen, paddingChar));
        }

        public static byte[] ToAsciiBytes(this string data)
        {
            if (data == null) { return null; }
            return Encoding.ASCII.GetBytes(data);
        }

        public static string ToAsciiString(this byte[] data)
        {
            if (data == null) { return ""; }
            return Encoding.ASCII.GetString(data).Replace("\0", "").Trim();
        }

        public static string ToDefaultString(this byte[] data)
        {
            return ToEncoddingString(data, Encoding.Default);
        }

        public static string ToEncoddingString(this byte[] data, Encoding encodding)
        {
            if (data == null) { return ""; }
            return encodding.GetString(data).Replace("\0", "").Trim();
        }

        /// <summary>
        /// 编码Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeToBase64(this string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        /// <summary>
        /// 编码Base64数组
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static string EncodeToBase64(this byte[] bs)
        {
            return Convert.ToBase64String(bs);
        }
        
        /// <summary>
        /// 解码Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeBase64String(this string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }

        public static DateTime? ToDateTime(this string value)
        {
            DateTime result;
            return DateTime.TryParse(value, out result) ? new DateTime?(result) : new DateTime?();
        }

        public static DateTime? ToDateTime(
          this string value,
          IFormatProvider provider,
          DateTimeStyles style)
        {
            DateTime result;
            return DateTime.TryParse(value, provider, style, out result) ? new DateTime?(result) : new DateTime?();
        }

        public static DateTime? ToDateTime(
          this string value,
          string format,
          IFormatProvider provider,
          DateTimeStyles style)
        {
            DateTime result;
            return DateTime.TryParseExact(value, format, provider, style, out result) ? new DateTime?(result) : new DateTime?();
        }

        public static DateTime? ToDateTime(
          this string value,
          string[] formats,
          IFormatProvider provider,
          DateTimeStyles style)
        {
            DateTime result;
            return DateTime.TryParseExact(value, formats, provider, style, out result) ? new DateTime?(result) : new DateTime?();
        }

        public static Decimal? ToDecimal(this string value)
        {
            Decimal result;
            return Decimal.TryParse(value, out result) ? new Decimal?(result) : new Decimal?();
        }

        public static Decimal? ToDecimal(
          this string value,
          NumberStyles style,
          IFormatProvider provider)
        {
            Decimal result;
            return Decimal.TryParse(value, style, provider, out result) ? new Decimal?(result) : new Decimal?();
        }

        public static double? ToDouble(this string value)
        {
            double result;
            return double.TryParse(value, out result) ? new double?(result) : new double?();
        }

        public static double? ToDouble(this string value, NumberStyles style, IFormatProvider provider)
        {
            double result;
            return double.TryParse(value, style, provider, out result) ? new double?(result) : new double?();
        }

        public static ulong? ToUInt64(this string value)
        {
            ulong result;
            return ulong.TryParse(value, out result) ? new ulong?(result) : new ulong?();
        }

        public static ulong? ToUInt64(this string value, NumberStyles style, IFormatProvider provider)
        {
            ulong result;
            return ulong.TryParse(value, style, provider, out result) ? new ulong?(result) : new ulong?();
        }

        public static long? ToInt64(this string value)
        {
            long result;
            return long.TryParse(value, out result) ? new long?(result) : new long?();
        }

        public static long? ToInt64(this string value, NumberStyles style, IFormatProvider provider)
        {
            long result;
            return long.TryParse(value, style, provider, out result) ? new long?(result) : new long?();
        }

        public static uint? ToUInt32(this string value)
        {
            uint result;
            return uint.TryParse(value, out result) ? new uint?(result) : new uint?();
        }

        public static uint? ToUInt32(this string value, NumberStyles style, IFormatProvider provider)
        {
            uint result;
            return uint.TryParse(value, style, provider, out result) ? new uint?(result) : new uint?();
        }

        public static int? ToInt32(this string value)
        {
            int result;
            return int.TryParse(value, out result) ? new int?(result) : new int?();
        }

        public static int? ToInt32(this string value, NumberStyles style, IFormatProvider provider)
        {
            int result;
            return int.TryParse(value, style, provider, out result) ? new int?(result) : new int?();
        }

        public static ushort? ToUInt16(this string value)
        {
            ushort result;
            return ushort.TryParse(value, out result) ? new ushort?(result) : new ushort?();
        }

        public static ushort? ToUInt16(this string value, NumberStyles style, IFormatProvider provider)
        {
            ushort result;
            return ushort.TryParse(value, style, provider, out result) ? new ushort?(result) : new ushort?();
        }

        public static short? ToInt16(this string value)
        {
            short result;
            return short.TryParse(value, out result) ? new short?(result) : new short?();
        }

        public static short? ToInt16(this string value, NumberStyles style, IFormatProvider provider)
        {
            short result;
            return short.TryParse(value, style, provider, out result) ? new short?(result) : new short?();
        }

        public static byte? ToByte(this string value)
        {
            byte result;
            return byte.TryParse(value, out result) ? new byte?(result) : new byte?();
        }

        public static byte? ToByte(this string value, NumberStyles style, IFormatProvider provider)
        {
            byte result;
            return byte.TryParse(value, style, provider, out result) ? new byte?(result) : new byte?();
        }

        public static ulong? ToUInt64(this string value, int radix)
        {
            if (radix < 2 && radix > 36)
                return new ulong?();
            ulong num1 = 0;
            foreach (char ch in value)
            {
                int num2;
                if (ch >= '0' && ch <= '9')
                    num2 = (int)ch - 48;
                else if (ch >= 'a' && ch <= 'z')
                {
                    num2 = 10 + (int)ch - 97;
                }
                else
                {
                    if (ch < 'A' || ch > 'Z')
                        return new ulong?();
                    num2 = 10 + (int)ch - 65;
                }
                if (num2 >= radix)
                    return new ulong?();
                num1 = num1 * (ulong)radix + (ulong)num2;
            }
            return new ulong?(num1);
        }

        public static long? ToInt64(this string value, int radix)
        {
            ulong? uint64 = value.ToUInt64(radix);
            return !uint64.HasValue ? new long?() : new long?((long)uint64.GetValueOrDefault());
        }

        public static uint? ToUInt32(this string value, int radix)
        {
            ulong? uint64 = value.ToUInt64(radix);
            return !uint64.HasValue ? new uint?() : new uint?((uint)uint64.GetValueOrDefault());
        }

        public static int? ToInt32(this string value, int radix)
        {
            ulong? uint64 = value.ToUInt64(radix);
            return !uint64.HasValue ? new int?() : new int?((int)uint64.GetValueOrDefault());
        }

        public static ushort? ToUInt16(this string value, int radix)
        {
            ulong? uint64 = value.ToUInt64(radix);
            return !uint64.HasValue ? new ushort?() : new ushort?((ushort)uint64.GetValueOrDefault());
        }

        public static short? ToInt16(this string value, int radix)
        {
            ulong? uint64 = value.ToUInt64(radix);
            return !uint64.HasValue ? new short?() : new short?((short)uint64.GetValueOrDefault());
        }

        public static byte? ToByte(this string value, int radix)
        {
            ulong? uint64 = value.ToUInt64(radix);
            return !uint64.HasValue ? new byte?() : new byte?((byte)uint64.GetValueOrDefault());
        }

        public static byte[] ToByteArray(this string value, int radix, int width)
        {
            List<byte> byteList = new List<byte>();
            for (int startIndex = 0; startIndex < value.Length; startIndex += width)
            {
                byte? nullable = startIndex + width > value.Length ? value.Substring(startIndex, value.Length - startIndex).ToByte(radix) : value.Substring(startIndex, width).ToByte(radix);
                if (!nullable.HasValue)
                    return (byte[])null;
                byteList.Add(nullable.Value);
            }
            return byteList.ToArray();
        }

        public static string[] Split(this string value, params string[] separator)
        {
            return value.Split(separator, StringSplitOptions.None);
        }

        public static string[] Split(this string value, string[] separator, int count)
        {
            return value.Split(separator, count, StringSplitOptions.None);
        }
    }
}
