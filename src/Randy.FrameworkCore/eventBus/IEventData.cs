using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore
{
    public interface IEventData
    {
        /// <summary>
        /// serial num
        /// </summary>
        string UniqueId { get; }
        /// <summary>
        /// The time when the event occured.
        /// </summary>
        DateTime EventTime { get;  }

        /// <summary>
        /// The object which triggers the event (optional).
        /// </summary>
        object EventSource { get; set; }
    }
}
