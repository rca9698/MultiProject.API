using Application.BankAccount.Command;
using Application.BankAccount.Query;
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
    public class BankAccountRepository : DbConnector, IBankAccountRepository
    {
        private readonly ILogger<BankAccountRepository> _logger;
        public BankAccountRepository(IConfiguration configuration,ILogger<BankAccountRepository> logger):base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<bool>> AddBankAccount(AddBankAccountCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@BankName", entity.BankName);
                parameters.Add("@AccountNumber", entity.AccountNumber);
                parameters.Add("@IFSCCode", entity.IFSCCode);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertBankAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > AddBankAccount");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> DeleteBankAccount(DeleteBankAccountCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertBankAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > DeleteBankAccount");
            }
            return returnType;
        }

        public async Task<ReturnType<BankDetails>> GetBankAccounts(GetBankAccountQuery entity)
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_GetBankAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetBankAccounts");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> updateBankAccount(UpdateBankAccountCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@BankName", entity.BankName);
                parameters.Add("@AccountNumber", entity.AccountNumber);
                parameters.Add("@IFSCCode", entity.IFSCCode);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_UpdateBankAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > updateBankAccount");
            }
            return returnType;
        }
    }
}
