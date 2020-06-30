namespace System
{
    public static class Int64Extension
    {
        public static string ToString(this long value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        public static byte[] ToByteArray(this long value, Endian endian)
        {
            return ((ulong)value).ToByteArray(endian);
        }

        public static long Reverse(this long value)
        {
            return (long)((ulong)value).Reverse();
        }
    }
}
