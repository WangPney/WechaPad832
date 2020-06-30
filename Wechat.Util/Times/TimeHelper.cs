using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.Times
{
    public class TimeHelper
    {
        public static long CurrentTime()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }


        public static string GetRandom()
        {
            var random = new Random().Next(100000, 999999);
            long time = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return $"{time}{random}";
        }
    }
}
