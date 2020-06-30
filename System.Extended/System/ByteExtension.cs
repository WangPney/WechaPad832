namespace System
{
    public static class ByteExtension
    {
        public static string ToString(this byte value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        public static byte Reverse(this byte value)
        {
            byte num = 0;
            for (int index = 0; index < 8; ++index)
            {
                num = (byte)((uint)(byte)((uint)num << 1) | (uint)value & 1U);
                value >>= 1;
            }
            return num;
        }
    }
}
