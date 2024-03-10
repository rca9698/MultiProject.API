using Application.Common.Interface;
using Application.DropDown.Command;
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
    public class DropDownRepository : DbConnector, IDropDownRepository
    {
        private readonly ILogger<DropDownRepository> _logger;
        public DropDownRepository(IConfiguration configuration, ILogger<DropDownRepository> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<DropDownDetails>> StatusTypes(GetStatusTypeCommand entity)
        {
            ReturnType<DropDownDetails> returnType = new ReturnType<DropDownDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<DropDownDetails>("USP_GetStatusType", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DropDownRepository > StatusTypes");
            }
            return returnType;
        }

        public async Task<ReturnType<DropDownDetails>> TransactionTypes(TransactionTypeCommand entity)
        {
            ReturnType<DropDownDetails> returnType = new ReturnType<DropDownDetails>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<DropDownDetails>("USP_GetTransactionType", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DropDownRepository > TransactionTypes");
            }
            return returnType;
        }
    }
}
