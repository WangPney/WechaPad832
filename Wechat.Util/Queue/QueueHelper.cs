using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wechat.Util.Cache;
using Wechat.Util.Extensions;
using Wechat.Util.Log;
using Wechat.Util;

namespace Wechat.Util
{
    public class QueueObjBase : RequestBase
    {
        public int MsgId { get; set; }
        public long NewMsgId { get; set; }

    }
    public class UploadFileObj : QueueObjBase
    {       

        public string ToWxId { get; set; }

        public long Length { get; set; }

        public long LongDataLength { get; set; }
        /// <summary>
        /// 3:图片; 34:语音;43:视频
        /// </summary>
        public int MsgType { get; set; }


        public byte[] Buffer { get; set; }

    }



    public class QueueHelper<T> where T : QueueObjBase
    {
        private static Queue<T> _tasks = new Queue<T>();

        // 为保证线程安全，使用一个锁来保护_task的访问
        //private readonly static object _locker = new object();

        // 通过 _wh 给工作线程发信号
        private static Semaphore sema = new Semaphore(0, 10);

        private static IList<Func<T, string>> actions = new List<Func<T, string>>();

        private static RedisCache redis = new RedisCache("127.0.0.1:6379");// RedisCache.CreateInstance();

        private static ILog log = Logger.GetLog<QueueObjBase>();

        static QueueHelper()
        {
            init();
        }


        private static void init()
        {
            var cacheResult = redis.HashGetAll<T>(ConstCacheKey.GetQueueKey(typeof(T).Name));
            //lock (_locker)
            //{
            foreach (var item in cacheResult)
            {
                _tasks.Enqueue(item);
                sema.Release();
            }
            //}
        }


        /// <summary>
        /// 0 未启动 1：已启动 2：已关闭
        /// </summary>
        public static int State { get; private set; } = 0;

        public static void Register(Func<T, string> func)
        {
            actions.Add(func);
        }

        /// <summary>
        /// 插入任务
        /// </summary>
        /// <param name="obj"></param>
        public static void EnqueueTask(T obj)
        {
            log.Info($"插入任务{obj.ToJson()}");
            //lock (_locker)
            //{                
            // 向队列中插入任务 
            _tasks.Enqueue(obj);

            //}
            redis.HashSet(ConstCacheKey.GetQueueKey(typeof(T).Name), ConstCacheKey.GetQueueMsgKey(obj.WxId, obj.MsgId), obj);
            sema.Release();
        }

        public static void Start()
        {

            State = 1;
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                while (true)
                {
                    if (State == 2)
                    {
                        return;
                    }
                    T obj = null;

                    sema.WaitOne();
                    //lock (_locker)
                    //{
                    if (_tasks.Count > 0)
                    {
                        obj = _tasks.Dequeue(); // 有任务时，出列任务 
                    }
                    //}
                    // 任务不为null时，处理并保存数据
                    if (obj != null)
                    {
                        WorkAsync(obj);
                    }
                }
            });
        }

        public static void Stop()
        {
            State = 2;
        }


        public static void WorkAsync(T obj)
        {
            foreach (var action in actions)
            {
                Task.Run(() =>
                {
                    action(obj);
                    redis.HashDelete(ConstCacheKey.GetQueueKey(typeof(T).Name), ConstCacheKey.GetQueueMsgKey(obj.WxId, obj.MsgId));

                });
            }
        }

        public static string Work(T obj)
        {
            string result = null;
            bool isFalg = true;
            foreach (var action in actions)
            {
                try
                {
                    result = action(obj);
                }
                catch (Exception ex)
                {
                    isFalg = false;
                    Logger.GetLog<QueueHelper<T>>().Error(ex);
                }
            }
            if (isFalg)
            {
                redis.HashDelete(ConstCacheKey.GetQueueKey(typeof(T).Name), ConstCacheKey.GetQueueMsgKey(obj.WxId, obj.MsgId));
            }
            return result;
        }







    }
}
