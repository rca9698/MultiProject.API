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
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories
{
    public class BankAccountRepository : DbConnector, IBankAccountRepository
    {
        private readonly ILogger<BankAccountRepository> _logger;
        public BankAccountRepository(IConfiguration configuration,ILogger<BankAccountRepository> logger):base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<string>> AddBankAccount(AddBankAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@BankName", entity.BankName);
                parameters.Add("@AccountHolderName", entity.AccountHolderName);
                parameters.Add("@AccountNumber", entity.AccountNumber);
                parameters.Add("@IFSCCode", entity.IFSCCode);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<ReturnType<BankDetails>> SetDefaultBankAccount(long sessionUser, long BankDetailID)
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", sessionUser);
                parameters.Add("@bankDetailID", BankDetailID);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_UpdateDefaultBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal; 
                }
                GetBankAccountQuery entity = new GetBankAccountQuery()
                {
                    UserId = sessionUser,
                    SessionUser = sessionUser,
                    IsActive = 1
                };
                returnType = await GetBankAccounts(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetBankAccounts");
            }
            return returnType;
        }

        public async Task<ReturnType<BankDetails>> GetBankAccountById(long BankDetailID)
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@bankDetailID", BankDetailID);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<BankDetails>("USP_GetBankAccountById", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal; 
                    returnType.ReturnVal = res.FirstOrDefault(); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetBankAccountById");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> DeleteBankAccount(DeleteBankAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteBankAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<BankDetails>("USP_GetBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                    returnType.ReturnVal = res.FirstOrDefault(x => x.IsDefault == true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetBankAccounts");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> updateBankAccount(UpdateBankAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@BankName", entity.BankName);
                parameters.Add("@AccountNumber", entity.AccountNumber);
                parameters.Add("@IFSCCode", entity.IFSCCode);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
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



        public async Task<ReturnType<string>> AddUpdateAdminBankAccount(AddUpdateAdminBankAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BankName", entity.BankName);
                parameters.Add("@AccountHolderName", entity.AccountHolderName);
                parameters.Add("@AccountNumber", entity.AccountNumber);
                parameters.Add("@IFSCCode", entity.IFSCCode);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateAdminBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<ReturnType<BankDetails>> GetAdminBankAccounts()
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<BankDetails>("USP_GetAdminBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                    returnType.ReturnVal = res.FirstOrDefault(x=>x.IsDefault == true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetBankAccounts");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> SetDefaultAdminBankAccount(long sessionUser, long BankDetailID)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@sessionUser", sessionUser);
                parameters.Add("@bankDetailID", BankDetailID);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_UpdateDefaultAdminBankAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > SetDefaultAdminBankAccount");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> DeleteAdminBankAccount(DeleteAdminBankAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BankId", entity.BankId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteAdminBankAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
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



        public async Task<ReturnType<string>> AddUpdateAdminUpiAccount(AddUpdateAdminUpiAccountCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UpiDetailID", entity.UpiDetailID);
                parameters.Add("@UpiId", entity.UpiId);
                parameters.Add("@UserName", entity.UserName);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateAdminUpiAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > AddUpdateAdminUpiAccount");
            }
            return returnType;
        }

        public async Task<ReturnType<BankDetails>> GetAdminUpiAccount()
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<BankDetails>("USP_GetAdminUpiAccounts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                    returnType.ReturnVal = res.FirstOrDefault(x => x.IsDefault == true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetAdminUpiAccounts");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> SetDefaultAdminUpiAccount(long sessionUser, long UpiID)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", sessionUser);
                parameters.Add("@UpiID", UpiID);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_UpdateDefaultAdminUpi", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > SetDefaultAdminBankAccount");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> DeleteAdminUpiAccount(long sessionUser, long UpiID)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", sessionUser);
                parameters.Add("@UpiID", UpiID);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteAdminUpiAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > DeleteAdminUpiAccount");
            }
            return returnType;
        }



        public async Task<ReturnType<string>> AddUpdateAdminQRCode(long SessionUser,string UserName)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName);
                parameters.Add("@SessionUser", SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateAdminQRCode", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > AddUpdateAdminQRCode");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> AddUpdateAdminQRDetail(string qrName, string fileName, string extenstion, string userId, string SessionUser)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", qrName);
                parameters.Add("@fileName", fileName);
                parameters.Add("@fileextension", extenstion);
                parameters.Add("@SessionUser", SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateAdminQRCode", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > AddUpdateAdminQRDetail");
            }
            return returnType;
        }

        public async Task<ReturnType<BankDetails>> GetAdminQRCode()
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<BankDetails>("USP_GetAdminQRCodes", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                    returnType.ReturnVal = res.FirstOrDefault(x => x.IsDefault == true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > GetAdminQRCode");
            }
            return returnType;
        }


        public async Task<ReturnType<string>> DeleteAdminQrAccount(long sessionUser, long QrID)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", sessionUser);
                parameters.Add("@QrID", QrID);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteAdminQrAccount", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountRepository > DeleteAdminUpiAccount");
            }
            return returnType;
        }
    }
}
