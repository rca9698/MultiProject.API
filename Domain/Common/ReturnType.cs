using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ReturnType<T>
    {
        public T ReturnVal { get; set; }
        public ReturnStatus ReturnStatus { get; set; }
        public List<T> ReturnList { get; set; }
        public string ReturnMessage { get; set; }
        public int PaginationCount { get; set; }
        public int TotalCount { get; set; }
    }
}
