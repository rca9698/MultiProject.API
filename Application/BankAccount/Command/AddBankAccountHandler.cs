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
    public class AddBankAccountHandler : IRequestHandler<AddBankAccountCommand, ReturnType<string>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public AddBankAccountHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public Task<ReturnType<string>> Handle(AddBankAccountCommand request, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.AddBankAccount(request);
        }
    }
}
