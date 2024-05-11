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
    public class IDRequestListHandler : IRequestHandler<IDRequestListQuery, ReturnType<IDRequest>>
    {
        private readonly IIDRepository _accountRepository;
        public IDRequestListHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<IDRequest>> Handle(IDRequestListQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.IDRequestList(request);
        }
    }
}
