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
    public class UpdateBankAccountHander : IRequestHandler<UpdateBankAccountCommand, ReturnType<bool>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public UpdateBankAccountHander(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<ReturnType<bool>> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.updateBankAccount(request);
        }
    }
}
