using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class DeleteCoinsCommand : IRequest<ReturnType<string>>
    {
        public long UserId { get; set; }
        public long Coins { get; set; }
        public int CoinType { get; set; }
        public string CoinsRequestId { get; set; }
        public string DocumentDetailId { get; set; }
        public string ImageName { get; set; }
        public string ImageSize { get; set; }
        public string FileExtenstion { get; set; }
        public long SessionUser { get; set; }
    }
}
