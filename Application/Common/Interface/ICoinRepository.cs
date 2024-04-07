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
        Task<ReturnType<CoinsRequestModel>> ListCoinsDetail(ListCoinsDetailQuery entity);
        Task<ReturnType<CoinsRequestModel>> GetCoinsRequest(GetCoinsRequestQuery entity);
        Task<ReturnType<CoinsToAccountRequestModel>> GetCoinsToAccountRequest(GetCoinsToAccountRequestQuery entity);
        Task<ReturnType<string>> UpdateCoins(UpdateCoinsCommand entity);
        Task<ReturnType<string>> AddCoinsRequest(InsertCoinRequestCommand entity);
        Task<ReturnType<string>> WithDrawCoinsRequest(DeleteCoinRequestCommand entity);
        Task<ReturnType<string>> UpdateCoinsToAccountRequest(UpdateCoinsToAccountRequestCommand entity);
        Task<ReturnType<string>> UpdateCoinsToAccount(UpdateCoinsToAccountCommand entity);
    }
}
