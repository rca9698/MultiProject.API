using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Command
{
    public class DeleteBankAccountCommand : IRequest<ReturnType<string>>
    {
        public long UserId { get; set; }
        public long BankId { get; set; }
        public long SessionUser { get; set; }
    }
}
