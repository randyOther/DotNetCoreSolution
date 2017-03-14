using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure
{

    public class ReturnModel
    {
        private string _uniqueId;
        public ReturnModel()
        {
            _uniqueId = Guid.NewGuid().ToString();
        }

        public string UniqueID { get { return _uniqueId; } }

        public string ReturnMessage { get; set; }

        public bool Success { get; set; }
    }

    public class ReturnModel<T> : ReturnModel
       where T : new()
    {
        public T RerutnModel { get; set; }
    }
}
