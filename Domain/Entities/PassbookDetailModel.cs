﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PassbookDetailModel
    {
        public long UserId { get; set; }
        public int SiteId { get; set; }
        public int ActivityId { get; set; }

        public string PassbookHistoryId { get; set; }
        public string ActivityDescription { get; set; }
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public string SiteUserName { get; set; }
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
        public string ProofDocumentDetailID { get; set; }
        public string ProofFileExtenstion { get; set; }
        public string SitePassword { get; set; }
        public int Coins { get; set; }
        public string CreatedDate { get; set; }
        public string ApprovedDate { get; set; }

        public string TrxStatus { get; set; }
        public string TrxColor { get; set; }
        public string DisplayCoins { get; set; }
    }
}
