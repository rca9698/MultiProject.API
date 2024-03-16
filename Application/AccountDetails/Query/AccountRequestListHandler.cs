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
    public class AccountRequestListHandler : IRequestHandler<AccountRequestListQuery, ReturnType<AccountDetail>>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountRequestListHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<AccountDetail>> Handle(AccountRequestListQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.AccountRequestList(request);
        }
    }
}
