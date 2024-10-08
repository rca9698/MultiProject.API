﻿using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class DeleteIDRequestCommand : IRequest<ReturnType<string>>
    {
        public int AccountrequestId { get; set; }
        public long SessionUser { get; set; }
    }
}
