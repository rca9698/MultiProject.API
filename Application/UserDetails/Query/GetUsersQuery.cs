﻿using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserDetails.Query
{
    public class GetUsersQuery: IRequest<ReturnType<UserDetail>>
    {
        public long SessionUser { get; set; }
        public int PageNumber { get; set; }
    }
}
