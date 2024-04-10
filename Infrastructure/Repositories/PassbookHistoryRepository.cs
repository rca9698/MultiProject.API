using Application.Common.Interface;
using Application.Passbook.Query;
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
    public class PassbookHistoryRepository : DbConnector, IPassbookHistoryRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public PassbookHistoryRepository(IConfiguration configuration, ILogger<UserRepository> logger)
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<PassbookDetailModel>> GetPassbookHistory(GetPassbookHistoryQuery entity)
        {
            ReturnType<PassbookDetailModel> returnType = new ReturnType<PassbookDetailModel>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<PassbookDetailModel>("USP_GetPassbookHistory", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > GetPassbookHistory");
            }
            return returnType;
        }

        public async Task<ReturnType<PassbookDetailModel>> GetPassbookHistoryById(GetPassbookHistoryIdQuery entity)
        {
            ReturnType<PassbookDetailModel> returnType = new ReturnType<PassbookDetailModel>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PassbookId", entity.PassbookId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<PassbookDetailModel>("USP_GetPassbookHistoryId", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnVal = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountRepository > GetPassbookHistoryById");
            }
            return returnType;
        }

    }
}
