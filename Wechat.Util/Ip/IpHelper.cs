using System.Collections.Generic;
using System.IO;
using Wechat.Util.Extensions;

namespace Wechat.Util.Ip
{
    public class IpHelper
    {
        private static readonly string proxyIpJsonPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "proxyIp.json");
        private static bool _isLoad = false;

        private static int currentIndex = 0;

        public static bool IsProxy = false;

        private static IList<ProxyIpCacheResp> proxyIpCacheResps = null;

        static IpHelper()
        {
            //var isproxy = ConfigurationManager.AppSettings["IsProxy"]?.ToString()?.ToLower();
            //if (isproxy == "true")
            //{
            //    IsProxy = true;
            //}
        }

        public static IList<ProxyIpCacheResp> ProxyIps
        {
            get
            {
                if (!_isLoad)
                {
                    _isLoad = true;
                    proxyIpCacheResps = File.ReadAllText(proxyIpJsonPath).ToObj<IList<ProxyIpCacheResp>>();

                    if (proxyIpCacheResps == null)
                    {
                        return new List<ProxyIpCacheResp>();
                    }

                }
                return proxyIpCacheResps;

            }
        }



        /// <summary>
        /// 根据微信Id查找Ip
        /// 没有则创建一个
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public static ProxyIpCacheResp GetProxy()
        {
            ProxyIpCacheResp proxy = null;
            if (ProxyIps.Count == 0)
            {
                return null;
            }
            if (currentIndex >= ProxyIps.Count)
            {
                currentIndex = 0;
                proxy = ProxyIps[currentIndex];
            }
            else
            {
                proxy = ProxyIps[currentIndex];
                currentIndex++;
            }

            return proxy;
        }



    }


    public class ProxyIpCacheResp
    {
        public string ProxyIp { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Location { get; set; }

        public string Operator { get; set; }

        public override bool Equals(object obj)
        {
            var t = obj as ProxyIpCacheResp;
            return this.ProxyIp == t?.ProxyIp;
        }

        public override int GetHashCode()
        {
            return this.ProxyIp.GetHashCode();
        }

        /// <summary>
        /// 客户端代理Id
        /// </summary>
        public string ClientProxyId { get; set; }
    }
}

