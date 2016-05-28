using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInfo
{
    public class Logger
    {
  #region Singleton - допустим лишь один экземпляр данного класса
        private Logger() { }
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger()); 
        public static Logger Instance { get { return instance.Value; } }
  #endregion

        private OuterSource source = new Console();

        private OuterSource Source
        {
            get { return source; }
            set { source = value; }
        } 
        public void Info(string message)
        {
            Source.Write(string.Format(">>> [info] {0}", message));
        }

        public void Debug(string message)
        {
            Source.Write(string.Format(">>> [debug] {0}", message));
        }

        public void Warning(string message)
        {
            Source.Write(string.Format(">>> [warnings] {0}", message));
        }

        public void Error(string message)
        {
            Source.Write(string.Format(">>> [ERROR] {0}", message));
        }

    }
}
