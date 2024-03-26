using Application.CoinsDetail.Command;
using Application.CoinsDetail.Common.Interface;
using Application.CoinsDetail.Query;
using Dapper;
using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories
{
    public class CoinRepository : DbConnector, ICoinRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public CoinRepository(IConfiguration configuration, ILogger<UserRepository> logger)
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<CoinsRequestModel>> ListCoinsDetail(ListCoinsDetailQuery entity)
        {
            ReturnType<CoinsRequestModel> returnType = new ReturnType<CoinsRequestModel>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<CoinsRequestModel>("USP_GetListCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > ListCoinsDetail");
            }
            return returnType;
        }

        public async Task<ReturnType<CoinsRequestModel>> GetCoinsRequest(GetCoinsRequestQuery entity)
        {
            ReturnType<CoinsRequestModel> returnType = new ReturnType<CoinsRequestModel>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@CoinType", entity.CoinType);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<CoinsRequestModel>("USP_GetListCoinsRequest", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > GetCoinsRequest");
            }
            return returnType;
        }
        
        public async Task<ReturnType<bool>> AddCoins(AddCoinsCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", 1);
                parameters.Add("@CoinRequestID", entity.CoinRequestID);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > InsertCoins");
            }

            return returnType;
        }

        public async Task<ReturnType<bool>> DeleteCoins(DeleteCoinsCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", 0);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > DeleteCoins");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> AddCoinsRequest(InsertCoinRequestCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@DocumentDetailId", entity.DocumentDetailId);
                parameters.Add("@ImageSize", entity.ImageSize);
                parameters.Add("@FileExtenstion", entity.FileExtenstion);
                parameters.Add("@CoinType", 1);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoinsRequest", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > AddCoinsRequest");
            }

            return returnType;
        }


        public async Task<ReturnType<bool>> DeleteCoinsRequest(DeleteCoinRequestCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", 0);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoinsRequest", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > DeleteCoinsRequest");
            }

            return returnType;
        }
    }
}
