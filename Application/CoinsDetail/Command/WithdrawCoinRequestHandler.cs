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
    public class WithdrawCoinRequestHandler : IRequestHandler<WithdrawCoinRequestCommand, ReturnType<string>>
    {
        private readonly ICoinRepository _coinRepository;
        public WithdrawCoinRequestHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<string>> Handle(WithdrawCoinRequestCommand request, CancellationToken cancellationToken)
        {
            return await _coinRepository.WithDrawCoinsRequest(request);
        }
    }
}
