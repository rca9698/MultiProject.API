﻿using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LoginSgnup.Command
{
    public class LoginCommand : IRequest<ReturnType<UserDetail>>
    {
        public string UserNumber { get; set; }
        public string? OTP { get; set; }
        public string? Password { get; set; }
    }
}
