using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.CoinsDetail.Query
{
    public class ListCoinsDetailQuery : IRequest<ReturnType<CoinModel>>
    {
        public long UserId { get; set; }
        public long SessionUser { get; set; }
    }
}
