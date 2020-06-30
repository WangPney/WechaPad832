using System.Text;

namespace System
{
    public static class ByteArrayExtension
    {
        public static short GetInt16(this byte[] bytes, Endian endian)
        {
            return bytes.GetInt16(endian, 0);
        }

        public static short GetInt16(this byte[] bytes, Endian endian, int index)
        {
            return endian == Endian.Little ? (short)((int)bytes[index++] | (int)bytes[index] << 8) : (short)((int)bytes[index++] << 8 | (int)bytes[index]);
        }

        public static ushort GetUInt16(this byte[] bytes, Endian endian)
        {
            return (ushort)bytes.GetInt16(endian, 0);
        }

        public static ushort GetUInt16(this byte[] bytes, Endian endian, int index)
        {
            return (ushort)bytes.GetInt16(endian, index);
        }

        public static int GetInt32(this byte[] bytes, Endian endian)
        {
            return bytes.GetInt32(endian, 0);
        }

        public static int GetInt32(this byte[] bytes, Endian endian, int index)
        {
            return endian == Endian.Little ? (int)bytes[index++] | (int)bytes[index++] << 8 | (int)bytes[index++] << 16 | (int)bytes[index] << 24 : (int)bytes[index++] << 24 | (int)bytes[index++] << 16 | (int)bytes[index++] << 8 | (int)bytes[index];
        }

        public static uint GetUInt32(this byte[] bytes, Endian endian)
        {
            return (uint)bytes.GetInt32(endian, 0);
        }

        public static uint GetUInt32(this byte[] bytes, Endian endian, int index)
        {
            return (uint)bytes.GetInt32(endian, index);
        }

        public static long GetInt64(this byte[] bytes, Endian endian)
        {
            return bytes.GetInt64(endian, 0);
        }

        public static long GetInt64(this byte[] bytes, Endian endian, int index)
        {
            return endian == Endian.Little ? (long)bytes.GetUInt32(endian, index) | (long)bytes.GetInt32(endian, index + 4) << 32 : (long)bytes.GetInt32(endian, index) << 32 | (long)bytes.GetUInt32(endian, index + 4);
        }

        public static ulong GetUInt64(this byte[] bytes, Endian endian)
        {
            return (ulong)bytes.GetInt64(endian, 0);
        }

        public static ulong GetUInt64(this byte[] bytes, Endian endian, int index)
        {
            return (ulong)bytes.GetInt64(endian, index);
        }

        public static string ToString(this byte[] bytes, int radix, int width)
        {
            if (bytes.Length == 0)
                return string.Empty;
            StringBuilder stringBuilder = new StringBuilder(bytes.Length * width);
            for (int index = 0; index < bytes.Length; ++index)
                stringBuilder.Append(bytes[index].ToString(radix).PadLeft(width, '0'));
            return stringBuilder.ToString();
        }
        public static string ToBase64String(this byte[] inArray, int offset, int length, Base64FormattingOptions options)
        {
            return Convert.ToBase64String(inArray, offset, length, options);
        }

        public static string ToBase64String(this byte[] inArray, Base64FormattingOptions options)
        {
            return Convert.ToBase64String(inArray, options);
        }

        public static string ToBase64String(this byte[] inArray)
        {
            return Convert.ToBase64String(inArray);
        }

        public static string ToBase64String(this byte[] inArray, int offset, int length)
        {
            return Convert.ToBase64String(inArray, offset, length);
        }
    }
}
