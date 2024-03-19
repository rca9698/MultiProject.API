﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoinsRequestModel
    {
        public int UserId { get; set; }
        public long CoinsRequestId { get; set; }
        public long Coins { get; set; }
        public int CoinType { get; set; }
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public string CoinTypeColor { get; set; }//red//green
        public long SessionUser { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
