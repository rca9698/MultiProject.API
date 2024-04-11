using Application.BankAccount.Command;
using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccount.Query
{
    public class GetAdminBankAccountsHandler : IRequestHandler<GetAdminBankAccountsQuery,ReturnType<BankDetails>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public GetAdminBankAccountsHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public Task<ReturnType<BankDetails>> Handle(GetAdminBankAccountsQuery request, CancellationToken cancellationToken)
        {
            return _bankAccountRepository.GetAdminBankAccounts();
        }
    }
}
