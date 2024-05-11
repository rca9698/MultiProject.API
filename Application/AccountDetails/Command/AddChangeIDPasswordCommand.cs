using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class AddChangeIDPasswordCommand : IRequest<ReturnType<string>>
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
        public string Password { get; set; }
        public long SessionUser { get; set; }
    }
}
