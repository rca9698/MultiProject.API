﻿using System;
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
        public string UserId { get; set; }
        public long AccountId { get; set; }
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
