using Application.AccountDetails.Command;
using Application.AccountDetails.Query;
using Application.Common.Interface;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository :DbConnector, IAccountRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public AccountRepository(IConfiguration configuration, ILogger<UserRepository> logger)
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<AccountDetail>> GetAccounts(GetAccountsQuery entity)
        {
            ReturnType<AccountDetail> returnType = new ReturnType<AccountDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_GetAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > GetAccounts");
            }
            return returnType;
        }
        
        public async Task<ReturnType<AccountDetail>> AccountRequestList(AccountRequestListQuery entity)
        {
            ReturnType<AccountDetail> returnType = new ReturnType<AccountDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_AccountRequestList", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > AccountRequestList");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> AddAccount(AddAccountCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SiteID", entity.SiteId);
                parameters.Add("@UserName", entity.UserName);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > AddAccount");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> AddAccountRequest(AddAccountRequestCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SiteID", entity.SiteId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertAccountRequest", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > AddAccountRequest");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> DeleteAccount(DeleteAccountCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SiteID", entity.SiteID);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > DeleteAccount");
            }
            return returnType;
        }

    }
}
