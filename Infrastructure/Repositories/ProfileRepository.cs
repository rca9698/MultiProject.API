using Application.Common.Interface;
using Application.Profile.Command;
using Dapper;
using Domain.Common;
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
    public class ProfileRepository : DbConnector, IProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;
        public ProfileRepository(IConfiguration configuration, ILogger<ProfileRepository> logger)
            :base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<string>> ChangePassword(ChangePasswordCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CurrentPassword", entity.CurrentPassword);
                parameters.Add("@ChangePassword", entity.ChangePassword);
                parameters.Add("@ConfirmPassword", entity.ConfirmPassword);
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@MobileNumber", entity.MobileNumber);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateUserPassword", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
    }
}
