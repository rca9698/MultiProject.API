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
    public class GetAccountsHandler : IRequestHandler<GetAccountsQuery, ReturnType<AccountDetail>>
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountsHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<ReturnType<AccountDetail>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.GetAccounts(request);
        }
    }
}
