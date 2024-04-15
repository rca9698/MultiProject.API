using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class DeleteAccountRequestCoinsCommand : IRequest<ReturnType<string>>
    {
        public long CoinRequestId { get; set; }
        public long SessionUser { get; set; }
    }
}
