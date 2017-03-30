using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Infrastructure
{
    public class QueryPagedModel
    {
        /// <summary>
        /// begin index 1
        /// </summary>
        public int pageIndex { get; set; }

        public int pageSize { get; set; }

    }

    public class QueryPagedModel<T> : QueryPagedModel
    {
        public T Condition { get; set; }
    }

    public class ReturnPagedModel<T>
    {
        public int Total { get; set; }

        public List<T> DataList { get; set; }
    }
}
