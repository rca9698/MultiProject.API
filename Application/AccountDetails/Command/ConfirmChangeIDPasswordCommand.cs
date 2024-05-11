using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class ConfirmChangeIDPasswordCommand : IRequest<ReturnType<string>>
    {
        public long AccountId { get; set; }
        public string Password { get; set; }
        public long SessionUser { get; set; }
    }
}
