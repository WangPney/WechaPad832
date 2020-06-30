using log4net;
using System;
using System.IO;

namespace Wechat.Util.Log
{
    public class Logger
    {        

        static Logger()
        {       
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(path));
        
        }

        public static ILog GetLog<T>()
        {
            ILog log = LogManager.GetLogger(typeof(T));
            return log;
        }

        public static ILog GetLog(Type type)
        {
            ILog log = LogManager.GetLogger(type);
            return log;
        }

        public static ILog GetLog(string type)
        {
            ILog log = LogManager.GetLogger(type);
            return log;
        }

    }
}
