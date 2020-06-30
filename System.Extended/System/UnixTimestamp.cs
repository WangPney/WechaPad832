namespace System
{
    public static class UnixTimestamp
    {
        private static DateTime Origin = new DateTime(621355968000000000L, DateTimeKind.Utc);

        public static TimeSpan Now()
        {
            return UnixTimestamp.FromDateTime(DateTime.Now);
        }

        public static TimeSpan FromDateTime(DateTime time)
        {
            return time.ToUniversalTime() - UnixTimestamp.Origin;
        }

        public static DateTime ToDateTime(TimeSpan span)
        {
            return UnixTimestamp.Origin.Add(span);
        }
    }
}
