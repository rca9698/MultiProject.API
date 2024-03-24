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
    public class InsertCoinRequestCommand : IRequest<ReturnType<bool>>
    {
        public int Coins { get; set; }
        public string DocumentDetailId { get; set; }
        public string ImageName { get; set; }
        public string ImageSize { get; set; }
        public string FileExtenstion { get; set; }
        public long SessionUser { get; set; }
        public long UserId { get; set; }
    }
}
