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
    public class AddAccountHandler : IRequestHandler<AddAccountCommand, ReturnType<bool>>
    {
        private readonly IAccountRepository _accountRepository;
        public AddAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<bool>> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.AddAccount(request);
        }
    }
}
