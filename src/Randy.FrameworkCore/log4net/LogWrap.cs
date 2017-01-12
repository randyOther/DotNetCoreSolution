using log4net;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.log4net
{
    public class LogWrap : ILogWrap,IDependentInjection
    {

        public void WriteFormat(string msg,LogEnumType logType =LogEnumType.Info, params string[] args)
        {
            Write(string.Format(msg, args), logType);
        }


        public void Write(string message, LogEnumType logType)
        {
            Task.Run(() =>
            {
                try
                {
                    var logger = Log4netBuilder.GetLog();

                    if (logType == LogEnumType.Error)
                    {
                        logger.Error(message);
                    }
                    else
                    {
                        logger.Info(message);
                    }

                }
                catch (Exception ex)
                {
                   
                }

            });

        }
    }
}
