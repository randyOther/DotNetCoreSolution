using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore
{
    [Serializable]
    public abstract class EventData : IEventData
    {

        private string _guid;
        private DateTime? _occurTime;
        private object _source;
        public string UniqueId
        {
            get
            {
                if (string.IsNullOrEmpty(_guid))
                    _guid = Guid.NewGuid().ToString();

                return _guid;
            }
        }

        public EventData(object eventSource)
        {
            _source = eventSource;
        }

        public DateTime EventTime
        {
            get
            {
                if (_occurTime.HasValue == false)
                    _occurTime = DateTime.Now; 

                return _occurTime.Value;
            }
        }

        public object EventSource
        {
            get
            {
                return _source;
            }

            set
            {
                _source = value;
            }
        }
    }
}
