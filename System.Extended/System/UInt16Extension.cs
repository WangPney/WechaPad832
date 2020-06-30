namespace System
{
    public static class UInt16Extension
    {
        public static string ToString(this ushort value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        public static byte[] ToByteArray(this ushort value, Endian endian)
        {
            return endian == Endian.Little 
                ?new byte[2] { (byte)value, (byte)((uint)value >> 8) }
                :new byte[2]{(byte) ((uint) value >> 8),(byte) value};
        }

        public static ushort Reverse(this ushort value)
        {
            ushort num = 0;
            for (int index = 0; index < 16; ++index)
            {
                num = (ushort)((uint)(ushort)((uint)num << 1) | (uint)value & 1U);
                value >>= 1;
            }
            return num;
        }
    }
}
