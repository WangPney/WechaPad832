using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using Wechat.Util.Extensions;

namespace Wechat.Util.Cache
{
    /// <summary>
    /// Caching 的摘要说明
    /// </summary>
    public class CacheHelper
    {
        private static string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, ".cache");
        static CacheHelper()
        {
            if (!Directory.Exists(path))
            {

                Directory.CreateDirectory(path);
            }
        }
        private CacheHelper()
        {
        }
        private static CacheHelper _Singleton = null;
        private static object Singleton_Lock = new object();
        public static CacheHelper CreateInstance()
        {
            if (_Singleton == null) //双if +lock
            {
                lock (Singleton_Lock)
                {
                    if (_Singleton == null)
                    {
                        _Singleton = new CacheHelper();
                    }
                }
            }
            return _Singleton;
        }
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">
        /// <returns></returns>y
        public object Get(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            if (objCache[CacheKey] == null)
            {
                object obj = GetFileCache(CacheKey);
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    Add(CacheKey, obj);
                    return obj;
                }
            }

            return objCache[CacheKey];
        }

        public T Get<T>(string CacheKey) where T : class, new()
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            if (objCache[CacheKey] == null)
            {
                T obj = GetFileCache<T>(CacheKey);
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    Add(CacheKey, obj);
                    return obj;
                }
            }

            return objCache[CacheKey] as T;
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">
        /// <param name="objObject">
        public void Add(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);

            AddFileCache(CacheKey, objObject);
        }


        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">
        /// <param name="objObject">
        public void Add(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);

            AddFileCache(CacheKey, objObject);
        }

        /// <summary>  
        /// 设置数据缓存  
        /// </summary> 
        public void Add(string CacheKey, object objObject, uint timeout = 7200)
        {
            try
            {
                if (objObject == null) return;
                var objCache = HttpRuntime.Cache;
                //相对过期  
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null);  
                //绝对过期时间  
                objCache.Insert(CacheKey, objObject, null, DateTime.Now.AddSeconds(timeout), TimeSpan.Zero, CacheItemPriority.High, null);
                AddFileCache(CacheKey, objObject);
            }
            catch (Exception)
            {
                //throw;  
            }
        }
        /// <summary>
        /// 清除单一键缓存
        /// </summary>
        /// <param name="key">
        public void Remove(string CacheKey)
        {
            try
            {
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;
                objCache.Remove(CacheKey);

                RemoveFileCache(CacheKey);
            }
            catch { }
        }



        private void AddFileCache(string CacheKey, object objObject)
        {
            File.WriteAllText(Path.Combine(path, $".{CacheKey}"), objObject.ToJson());
        }

        private object GetFileCache(string CacheKey)
        {
            string filePath = Path.Combine(path, $".{CacheKey}");
            if (!File.Exists(filePath))
            {
                return null;
            }
            return File.ReadAllText(filePath).ToObj();
        }

        private T GetFileCache<T>(string CacheKey) where T : class, new()
        {
            string filePath = Path.Combine(path, $".{CacheKey}");
            if (!File.Exists(filePath))
            {
                return null;
            }
            return File.ReadAllText(filePath).ToObj<T>();
        }
        private void RemoveFileCache(string CacheKey)
        {
            string filePath = Path.Combine(path, $".{CacheKey}");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
