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
    public class DeleteIDRequestHandler : IRequestHandler<DeleteIDRequestCommand, ReturnType<string>>
    {
        private readonly IIDRepository _accountRepository;
        public DeleteIDRequestHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<string>> Handle(DeleteIDRequestCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.DeleteIDRequest(request);
        }
    }
}
