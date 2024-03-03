using Application.CoinsDetail.Command;
using Application.CoinsDetail.Common.Interface;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CoinRepository : DbConnector, ICoinRepository
    {
        protected CoinRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<ReturnType<CoinModel>> ListCoinsDetail()
        {
            ReturnType<CoinModel> returnType = new ReturnType<CoinModel>();
            try
            {

            }
            catch (Exception ex)
            {
                 
            }
            return returnType;
        }
        public async Task<ReturnType<bool>> InsertCoins(AddCoinsCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return returnType;
        }

        public async Task<ReturnType<bool>> DeleteCoins(DeleteCoinsCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return returnType;
        }
    }
}
