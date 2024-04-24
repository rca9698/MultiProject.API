using Application.Common.Interface;
using Application.LoginSgnup.Command;
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
    public class LoginSignupRepository : DbConnector, ILoginSignupRepository
    {
        public readonly ILogger<LoginSignupRepository> _logger;
        public LoginSignupRepository(IConfiguration configuration, ILogger<LoginSignupRepository> logger) 
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<UserDetail>> Login(LoginCommand entity)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", entity.UserNumber);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@OTP", entity.OTP);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<UserDetail>("USP_ValidateLogin", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = returnVal == 1 ? "LOGIN SUCCESS!" : "INVALID CRED!!";
                    returnType.ReturnVal = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupRepository > Login");
            }

            return returnType;
        }

        public async Task<ReturnType<string>> Signup(SignupCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", entity.UserName);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_SignupUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupRepository > Signup");
            }
            return returnType;
        }

        public async Task<ReturnType<Otp_Login_Model>> Generate_Otp(string MobileNumber)
        {
            ReturnType<Otp_Login_Model> returnType = new ReturnType<Otp_Login_Model>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MobileNumber", MobileNumber);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<Otp_Login_Model>("USP_GetOTP_Details", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnVal = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupRepository > Generate_Otp");
            }
            return returnType;
        }
    }
}
