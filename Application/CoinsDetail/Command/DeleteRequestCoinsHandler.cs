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
    public class DeleteRequestCoinsHandler : IRequestHandler<DeleteRequestCoinsCommand, ReturnType<string>>
    {
        private readonly ICoinRepository _coinRepository;
        public DeleteRequestCoinsHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<string>> Handle(DeleteRequestCoinsCommand request, CancellationToken cancellationToken)
        {
            return await _coinRepository.DeleteRequestCoins(request);
        }

    }
}
