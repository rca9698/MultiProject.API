using Application.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Command
{
    public class DeleteAdminBankAccountHandler : IRequestHandler<DeleteAdminBankAccountCommand, ReturnType<string>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public DeleteAdminBankAccountHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public Task<ReturnType<string>> Handle(DeleteAdminBankAccountCommand request, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.DeleteAdminBankAccount(request);
        }
    }
}
