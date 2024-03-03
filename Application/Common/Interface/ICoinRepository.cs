using Application.CoinsDetail.Command;
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
        public Task<ReturnType<CoinModel>> ListCoinsDetail();
        Task<ReturnType<bool>> InsertCoins(AddCoinsCommand entity);
        Task<ReturnType<bool>> DeleteCoins(DeleteCoinsCommand request);
    }
}
