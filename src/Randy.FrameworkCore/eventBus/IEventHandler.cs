using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore
{
    /// <summary>
    /// 泛型 in 逆变，允许父类隐式转换为子类
    /// </summary>
    /// <typeparam name="TEventData"></typeparam>
    public interface IEventHandler<in TEventData> :IDependentInjection
    {
        void HandleEvent(TEventData eventData);
    }
}
