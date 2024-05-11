using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class AddCloseIDCommand : IRequest<ReturnType<string>>
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
        public long SessionUser { get; set; }
    }
}
