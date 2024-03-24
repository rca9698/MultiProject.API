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
    public class InsertCoinRequestHandler : IRequestHandler<InsertCoinRequestCommand,ReturnType<bool>>
    {
        private readonly ICoinRepository _coinRepository;
        public InsertCoinRequestHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<bool>> Handle(InsertCoinRequestCommand request, CancellationToken cancellationToken)
        {
            return await _coinRepository.AddCoinsRequest(request);
        }
    }
}
