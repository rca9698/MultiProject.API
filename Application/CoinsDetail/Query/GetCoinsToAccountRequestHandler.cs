using Application.CoinsDetail.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Query
{
    public class GetCoinsToAccountRequestHandler : IRequestHandler<GetCoinsToAccountRequestQuery, ReturnType<CoinsToAccountRequestModel>>
    {
        private readonly ICoinRepository _coinRepository;
        public GetCoinsToAccountRequestHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }
        public Task<ReturnType<CoinsToAccountRequestModel>> Handle(GetCoinsToAccountRequestQuery request, CancellationToken cancellationToken)
        {
            return _coinRepository.GetCoinsToAccountRequest(request);
        }
    }
}
