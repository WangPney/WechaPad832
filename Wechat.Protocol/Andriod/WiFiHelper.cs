using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Protocol.Andriod
{
    public class WiFiHelper
    {
        private static string[] wifiname = new string[3]
        {
              "TP-LINK_",
              "360WiFi-",
              "Tenda_"
        };

        public static string GetRanWifiName()
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            int index = ran.Next(0, 3);
            return wifiname[index];
        }
    }
}
