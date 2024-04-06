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
        Task<ReturnType<string>> AddCoins(AddCoinsCommand entity);
        Task<ReturnType<string>> AddCoinsRequest(InsertCoinRequestCommand entity);
        Task<ReturnType<string>> WithDrawCoinsRequest(DeleteCoinRequestCommand entity);
        Task<ReturnType<string>> DeleteCoins(DeleteCoinsCommand request);
        Task<ReturnType<string>> AddCoinsToAccountRequest(AddCoinsToAccountRequestCommand entity);
        Task<ReturnType<string>> WithDrawToAccountRequest(WithDrawToAccountCommand entity);
    }
}
