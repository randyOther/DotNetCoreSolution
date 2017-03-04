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
    public class LogRequestAttribute : BaseInterceptAttribute
    {
        private StringBuilder _sb = new StringBuilder();

        public override void OnEntry(IInvocation invocation)
        {

            var argsJson = "null";
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in invocation.Arguments)
                {
                    sb.AppendFormat("{0},", JsonSerialize.ToJson(item));
                }
                argsJson = sb.ToString();
            }

            _sb.AppendFormat("调用方法：{0},参数：{1}", invocation.Method.ToString(), argsJson);

        }

        public override void OnExcuted(IInvocation invocation)
        {
            //不能放在构造函数实例化 ？  还是注册容器实例顺序问题
            var Log = FrameworkCore.ioc.IocManager.Instance.Resolve<ILogWrap>();
            Log.Write(_sb.ToString());
        }

    }
}
