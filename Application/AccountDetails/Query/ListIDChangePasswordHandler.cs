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
    public class ListIDChangePasswordHandler : IRequestHandler<ListIDChangePasswordQuery, ReturnType<IDDetail>>
    {
        private readonly IIDRepository _accountRepository;
        public ListIDChangePasswordHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<ReturnType<IDDetail>> Handle(ListIDChangePasswordQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.ListIDChangePassword(request);
        }
    }
}
