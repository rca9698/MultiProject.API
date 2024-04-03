using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Query
{
    public class AccountRequestDetailsHandler : IRequestHandler<AccountRequestDetailsQuery, ReturnType<AccountRequest>>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountRequestDetailsHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<AccountRequest>> Handle(AccountRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.AccountRequestDetails(request);
        }
    }
}
