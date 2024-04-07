using Application.CoinsDetail.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class UpdateCoinsToAccountHandler : IRequestHandler<UpdateCoinsToAccountCommand, ReturnType<string>>
    {
        private readonly ICoinRepository _coinRepository;
        public UpdateCoinsToAccountHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<string>> Handle(UpdateCoinsToAccountCommand request, CancellationToken cancellationToken)
        {
            return await _coinRepository.UpdateCoinsToAccount(request);
        }
    }
}
