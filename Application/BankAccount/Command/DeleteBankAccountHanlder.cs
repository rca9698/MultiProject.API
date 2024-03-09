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
    public class DeleteBankAccountHanlder : IRequestHandler<DeleteBankAccountCommand, ReturnType<bool>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public DeleteBankAccountHanlder(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public Task<ReturnType<bool>> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.DeleteBankAccount(request);
        }
    }
}
