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
    public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequestCommand, ReturnType<string>>
    {
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountRequestHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<string>> Handle(DeleteAccountRequestCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.DeleteAccountRequest(request);
        }
    }
}
