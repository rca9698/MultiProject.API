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
    public class GetIDsHandler : IRequestHandler<GetIDsQuery, ReturnType<IDDetail>>
    {
        private readonly IIDRepository _accountRepository;
        public GetIDsHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<ReturnType<IDDetail>> Handle(GetIDsQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.GetIDs(request);
        }
    }
}
