﻿using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Query
{
    public class GetAccountsQuery : IRequest<ReturnType<AccountDetail>>
    {
        public long UserId { get; set; }
    }
}
