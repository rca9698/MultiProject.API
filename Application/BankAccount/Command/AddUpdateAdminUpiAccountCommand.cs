using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Command
{
    public class AddUpdateAdminUpiAccountCommand : IRequest<ReturnType<string>>
    {
        public long? UpiDetailID { get; set; }
        public string UserName { get; set; }
        public string UpiId { get; set; }
        public long SessionUser { get; set; }
    }
}
