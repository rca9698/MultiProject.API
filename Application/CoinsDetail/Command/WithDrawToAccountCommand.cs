using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class WithDrawToAccountCommand : IRequest<ReturnType<string>>
    {
        public long SiteId { get; set; }
        public long UserId { get; set; }
        public long Coins { get; set; }
        public long SessionUser { get; set; }
    }
}
