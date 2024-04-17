using Application.AccountDetails.Command;
using Application.Common.Interface;
using Application.UserDetails.Command;
using Application.UserDetails.Query;
using Dapper;
using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : DbConnector, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IConfiguration configuration,ILogger<UserRepository> logger) 
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<UserDetail>> GetUsers(GetUsersQuery entity)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<UserDetail>("USP_GetListUsers", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > GetUsers");
            }
            return returnType;
        }
        
        public async Task<ReturnType<string>> AddUser(AddUserCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@EmailId", entity.EmailId);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@MobileNumber", entity.MobileNumber);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_AddUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > AddUser");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> DeleteUser(DeleteUserCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > DeleteUser");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> UpdateUser(UpdateUserCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@EmailId", entity.EmailId);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@MobileNumber", entity.MobileNumber);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_AddUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > AddUser");
            }
            return returnType;
        }

        public async Task<ReturnType<UserDetail>> GetUserById(GetUserByIdQuery entity)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<UserDetail>("USP_GetUserById", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnVal = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > GetUsers");
            }
            return returnType;
        }

    }
}
