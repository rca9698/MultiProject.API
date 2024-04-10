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
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, ReturnType<string>>
    {
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<string>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.DeleteAccount(request);
        }
    }
}
