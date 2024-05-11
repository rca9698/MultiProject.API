using Application.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class AddIDHandler : IRequestHandler<AddIDCommand, ReturnType<string>>
    {
        private readonly IIDRepository _accountRepository;
        public AddIDHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<string>> Handle(AddIDCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.AddID(request);
        }
    }
}
