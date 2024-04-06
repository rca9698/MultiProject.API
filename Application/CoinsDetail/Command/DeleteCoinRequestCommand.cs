﻿using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class DeleteCoinRequestCommand : IRequest<ReturnType<string>>
    {
        public long UserId { get; set; }
        public long SessionUser { get; set; }
        public double Coins { get; set; }
    }
}
