using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoinsToAccountRequestModel
    {
        public string coinsRequestId { get; set; }
        public long UserId { get; set; }
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public long Coins { get; set; }
        public long TotalCoins { get; set; }
        public int CoinType { get; set; }
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public string CoinTypeColor { get; set; }//red//green
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
        public long SessionUser { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
