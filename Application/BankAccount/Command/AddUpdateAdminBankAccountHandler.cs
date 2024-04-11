using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Command
{
    public class AddUpdateAdminBankAccountHandler : IRequestHandler<AddUpdateAdminBankAccountCommand, ReturnType<string>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public AddUpdateAdminBankAccountHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<ReturnType<string>> Handle(AddUpdateAdminBankAccountCommand request, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.AddUpdateAdminBankAccount(request);
        }
    }
}
