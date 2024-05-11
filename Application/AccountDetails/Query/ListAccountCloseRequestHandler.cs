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
    public class ListAccountCloseRequestHandler : IRequestHandler<ListIDCloseRequestCommand, ReturnType<IDDetail>>
    {
        private readonly IIDRepository _accountRepository;
        public ListAccountCloseRequestHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<ReturnType<IDDetail>> Handle(ListIDCloseRequestCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.ListIDCloseRequest(request);
        }
    }
}
