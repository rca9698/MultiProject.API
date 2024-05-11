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
    public class ConfirmCloseIDHandler : IRequestHandler<ConfirmCloseIDCommand, ReturnType<string>>
    {
        private readonly IIDRepository _idRepository;
        public ConfirmCloseIDHandler(IIDRepository idRepository)
        {
            _idRepository = idRepository;
        }

        public Task<ReturnType<string>> Handle(ConfirmCloseIDCommand request, CancellationToken cancellationToken)
        {
            return _idRepository.ConfirmCloseID(request);
        }
    }
}
