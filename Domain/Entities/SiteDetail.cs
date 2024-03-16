using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SiteDetail
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public string SiteImg { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
