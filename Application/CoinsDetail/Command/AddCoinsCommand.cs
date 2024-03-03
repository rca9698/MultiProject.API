using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class AddCoinsCommand : IRequest<ReturnType<bool>>
    {
        public long UserId { get; set; }
        public long SessionUser { get; set; }
        public double Coin { get; set; }
    }
}
