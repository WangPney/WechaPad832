namespace System
{
    public static class RandomExtension
    {
        public static byte[] NextBytes(this Random random, int count)
        {
            byte[] buffer = new byte[count];
            random.NextBytes(buffer);
            return buffer;
        }
    }
}
