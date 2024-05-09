using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class DepositeCoinsByUseridCommand
    {
        public long UserId { get; set; }
        public long SessionUser { get; set; }
        public int Coins { get; set; }
        public int CoinType { get; set; }
    }
}
