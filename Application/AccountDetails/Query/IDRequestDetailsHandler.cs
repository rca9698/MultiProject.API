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
    public class IDRequestDetailsHandler : IRequestHandler<IDRequestDetailsQuery, ReturnType<IDRequest>>
    {
        private readonly IIDRepository _accountRepository;
        public IDRequestDetailsHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<IDRequest>> Handle(IDRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            return _accountRepository.IDRequestDetails(request);
        }
    }
}
