using Application.AccountDetails.Query;
using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class ConfirmChangeIDPasswordHandler : IRequestHandler<ConfirmChangeIDPasswordCommand,ReturnType<string>>
    {
        private readonly IIDRepository _accountRepository;
        public ConfirmChangeIDPasswordHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<ReturnType<string>> Handle(ConfirmChangeIDPasswordCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.ConfirmChangeIDPassword(request);
        }
    }
}
