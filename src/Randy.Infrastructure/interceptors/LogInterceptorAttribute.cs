using Castle.DynamicProxy;
using Randy.FrameworkCore.aspects;
using Randy.FrameworkCore.log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randy.Infrastructure.interceptors
{
    public class LogInterceptorAttribute : BaseInterceptAttribute
    {
        public ILogWrap Log { get; set; }
        private StringBuilder _sb = new StringBuilder();

        public override void OnEntry(IInvocation invocation)
        {
            _sb.AppendFormat(invocation.MethodInvocationTarget.ToString() + invocation.Method.ToString());
            
        }

        public override void OnExcuted(IInvocation invocation)
        {
            //invocation.ReturnValue

            var args= invocation.Arguments;
            //invocation.GetArgumentValue

            Log.Write(_sb.ToString());
        }

    }
}
