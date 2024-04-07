using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class UpdateCoinsToAccountCommand : IRequest<ReturnType<string>>
    {
        public string coinsRequestId { get; set; }
        public long UserId { get; set; }
        public int SiteId { get; set; }
        public long Coins { get; set; }
        public int CoinType { get; set; }
        public long SessionUser { get; set; }
    }
}
