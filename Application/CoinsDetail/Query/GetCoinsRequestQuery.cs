﻿using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Query
{
    public class GetCoinsRequestQuery : IRequest<ReturnType<CoinModel>>
    {
        public long UserId { get; set; }
        public long SessionUser { get; set; }
    }
}
