using log4net;
using System;
using System.Linq;
using System.Threading;

namespace Randy.FrameworkCore.log4net
{
    public interface ILogWrap
    {
        /// <summary>
        /// write log
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="logType">info or error</param>
        void Write(string message, LogEnumType logType = LogEnumType.Info, Exception exp = null);

        /// <summary>
        ///  write log by format message
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="logType">info or error</param>
        /// <param name="args">arguments</param>
        void WriteFormat(string message, LogEnumType logType = LogEnumType.Info, params string[] args);
    }
}
