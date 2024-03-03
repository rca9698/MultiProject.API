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
    public class ListCoinsDetailHandler : IRequestHandler<ListCoinsDetailQuery,ReturnType<CoinModel>>
    {
        private readonly ICoinRepository _coinRepository;
        public ListCoinsDetailHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public Task<ReturnType<CoinModel>> Handle(ListCoinsDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
