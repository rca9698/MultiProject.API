using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoinModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public double Coin { get; set; }
        public double CoinType { get; set; }//cr-c/dr-d
        public string CoinColor { get; set; }//red//green
    }
}
