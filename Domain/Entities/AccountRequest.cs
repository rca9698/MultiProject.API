﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountRequest
    {
        public long AccountRequestID { get; set; }
        public int UserId { get; set; }
        public string UserNumber { get; set; }
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public int SiteId { get; set; }
        public string UserName { get; set; }
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
    }
}
