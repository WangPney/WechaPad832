using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wechat.Util.Cache
{
    /// <summary>
    /// 缓存键
    /// </summary>
    public class ConstCacheKey
    {
        /// <summary>
        /// 获取UUid
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static string GetUuidKey(string uuid)
        {
            return $"customer:service:uuid:Wechat_Uuid_{uuid}";
        }

        /// <summary>
        /// 获取微信Id
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public static string GetWxIdKey(string wxId)
        {
            return $"customer:service:wxid:Wechat_WxId_{wxId}";
        }


        /// <summary>
        /// 获取微信Id
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public static string GetWxIdKey()
        {
            return $"customer:service:wxid";
        }



        /// <summary>
        /// 获取队列Id
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetQueueKey(string type)
        {
            return $"customer:service:queue:Wechat_{type}";
        }

        /// <summary>
        /// 获取队列消息
        /// </summary>
        ///  <param name="wxId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static string GetQueueMsgKey(string wxId, int msgId)
        {
            return $"wxId_{msgId}";
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public static string GetMchIdKey()
        {
            return $"customer:service";
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public static string GetMchIdKey(string wxId)
        {            
            return $"customer:service:merchant_wechat_mapping_{wxId}";
        }
    }
}