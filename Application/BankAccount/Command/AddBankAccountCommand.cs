using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Command
{
    public class AddBankAccountCommand : IRequest<ReturnType<string>>
    {
        public long UserId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public long SessionUser { get; set; }
    }
}
