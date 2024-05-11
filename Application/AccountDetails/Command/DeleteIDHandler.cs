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
    public class DeleteIDHandler : IRequestHandler<DeleteIDCommand, ReturnType<string>>
    {
        private readonly IIDRepository _accountRepository;
        public DeleteIDHandler(IIDRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<ReturnType<string>> Handle(DeleteIDCommand request, CancellationToken cancellationToken)
        {
            return _accountRepository.DeleteID(request);
        }
    }
}
