using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IDRequest
    {
        public long AccountRequestID { get; set; }
        public long UserId { get; set; }
        public string UserNumber { get; set; }
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public int SiteId { get; set; }
        public string UserName { get; set; }
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
        public string CreatedDate { get; set; }
    }
}
