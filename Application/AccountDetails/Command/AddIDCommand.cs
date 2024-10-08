﻿using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class AddIDCommand : IRequest<ReturnType<string>>
    {
        public long AccountRequestId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long SessionUser { get; set; }
    }
}
