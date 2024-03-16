using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountDetail
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        public int AppNumber { get; set; }
        public string AppName { get; set; }
        public string AppIcon { get; set; }
    }
}
