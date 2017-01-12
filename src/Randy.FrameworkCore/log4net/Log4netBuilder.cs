using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net.Core;
using log4net.ObjectRenderer;
using log4net.Plugin;
using log4net.Util;
using System.Collections;
using System.Reflection;

namespace Randy.FrameworkCore.log4net
{
    public class Log4netBuilder
    {

        private static StringBuilder _xml = new StringBuilder();
        private static ILog _log;

        public static ILog GetLog()
        {
            
            if (_log != null)
                return _log;

            LogConfiguration();
            _log = LogManager.GetLogger(typeof(ILog));
            
            return _log; ;
        }


        private static void LogConfiguration()
        {

            var repository = (Hierarchy)LogManager.GetRepository(typeof(Hierarchy).GetTypeInfo().Assembly);

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "记录时间：%date 线程ID:[%thread] 日志级别：%-5level 日志描述：%message%newline%newline";
            patternLayout.ActivateOptions();


            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = @"Logs\log.txt";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = -1;  //not limit
            roller.MaximumFileSize = "300MB";  //300MB  split file support GB/MB/KB
            roller.RollingStyle = RollingFileAppender.RollingMode.Composite;
            roller.StaticLogFileName = true;
            roller.DatePattern = "_yyyy-MM-dd";
            roller.Encoding = Encoding.UTF8;
            roller.LockingModel = new FileAppender.MinimalLock();
            roller.ActivateOptions();
            repository.Root.AddAppender(roller);


            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            repository.Root.AddAppender(memory);

            repository.Configured = true;
        }

    }

    public class InfoRepository : ILoggerRepository
    {
        public ICollection ConfigurationMessages
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Configured
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public LevelMap LevelMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public PluginMap PluginMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PropertiesDictionary Properties
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public RendererMap RendererMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Level Threshold
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public event LoggerRepositoryConfigurationChangedEventHandler ConfigurationChanged;
        public event LoggerRepositoryConfigurationResetEventHandler ConfigurationReset;
        public event LoggerRepositoryShutdownEventHandler ShutdownEvent;

        public ILogger Exists(string name)
        {
            throw new NotImplementedException();
        }

        public IAppender[] GetAppenders()
        {
            throw new NotImplementedException();
        }

        public ILogger[] GetCurrentLoggers()
        {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string name)
        {
            throw new NotImplementedException();
        }

        public void Log(LoggingEvent logEvent)
        {
            throw new NotImplementedException();
        }

        public void ResetConfiguration()
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }
    }



}
