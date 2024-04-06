﻿using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Query
{
    public class GetAdminBankAccountCommand : IRequest<ReturnType<BankDetails>>
    {
    }
}
