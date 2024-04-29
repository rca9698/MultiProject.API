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

        public async Task<ReturnType<CoinsToAccountRequestModel>> GetCoinsToAccountRequest(GetCoinsToAccountRequestQuery entity)
        {
            ReturnType<CoinsToAccountRequestModel> returnType = new ReturnType<CoinsToAccountRequestModel>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@CoinType", entity.CoinType);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<CoinsToAccountRequestModel>("USP_GetListCoinsToAccountRequest", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > GetCoinsToAccountRequest");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> UpdateCoins(UpdateCoinsCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", entity.CoinType);
                parameters.Add("@CoinRequestID", entity.coinsRequestId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);
 
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    returnType.ReturnStatus = parameters.Get<ReturnStatus>("@ReturnVal");
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > InsertCoins");
            }

            return returnType;
        } 

        public async Task<ReturnType<string>> DeleteCoins(DeleteCoinsCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", entity.CoinType);
                parameters.Add("@CoinRequestID", entity.CoinsRequestId);
                parameters.Add("@documentDetailId", entity.DocumentDetailId);
                parameters.Add("@fileExtenstion", entity.FileExtenstion);
                parameters.Add("@imageSize", entity.ImageSize);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);
 
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    returnType.ReturnStatus = parameters.Get<ReturnStatus>("@ReturnVal");
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > InsertCoins");
            }

            return returnType;
        } 


        public async Task<ReturnType<string>> AddCoinsRequest(InsertCoinRequestCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@DocumentDetailId", entity.DocumentDetailId);
                parameters.Add("@ImageSize", entity.ImageSize);
                parameters.Add("@FileExtenstion", entity.FileExtenstion);
                parameters.Add("@CoinType", 1);//Add To wallet
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

        public async Task<ReturnType<string>> WithDrawCoinsRequest(WithdrawCoinRequestCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@CoinType", 0);//withdraw from wallet
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

        public async Task<ReturnType<string>> UpdateCoinsToAccountRequest(UpdateCoinsToAccountRequestCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SiteId", entity.SiteId);
                parameters.Add("@accountId", entity.AccountId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", entity.CoinType);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoinsToAccountRequest", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > AddCoinsToAccountRequest");
            }

            return returnType;
        }

        public async Task<ReturnType<string>> UpdateCoinsToAccount(UpdateCoinsToAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SiteId", entity.SiteId);
                parameters.Add("@Coin", entity.Coins);
                parameters.Add("@CoinType", entity.CoinType);
                parameters.Add("@CoinRequestID", entity.coinsRequestId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateCoinsToAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    returnType.ReturnStatus = parameters.Get<ReturnStatus>("@ReturnVal");
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > InsertCoins");
            }

            return returnType;
        }

        public async Task<ReturnType<string>> DeleteAccountRequestCoins(DeleteAccountRequestCoinsCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CoinRequestId", entity.CoinRequestId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteAccountRequestCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > DeleteAccountRequestCoins");
            }

            return returnType;
        }

        public async Task<ReturnType<string>> DeleteRequestCoins(DeleteRequestCoinsCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CoinRequestId", entity.CoinRequestId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteRequestCoins", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
