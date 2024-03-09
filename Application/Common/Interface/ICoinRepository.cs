using Application.CoinsDetail.Command;
using Application.CoinsDetail.Query;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Common.Interface
{
    public interface ICoinRepository
    {
        Task<ReturnType<CoinModel>> ListCoinsDetail(ListCoinsDetailQuery entity);
        Task<ReturnType<bool>> AddCoins(AddCoinsCommand entity);
        Task<ReturnType<bool>> DeleteCoins(DeleteCoinsCommand request);
    }
}
