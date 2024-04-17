using Application.CoinsDetail.Query;
using Application.Common.Interface;
using Application.Home.Command;
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
    public class HomeRepository : DbConnector, IHomeRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public HomeRepository(IConfiguration configuration, ILogger<UserRepository> logger)
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<DashboardImages>> GetDashboardImages()
        {
            ReturnType<DashboardImages> returnType = new ReturnType<DashboardImages>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<DashboardImages>("USP_GetDahboardImages", parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<ReturnType<string>> InsertDashboardImages(InsertDashboardImagesCommand entity)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentDetailId", entity.DocumentDetailId);
                parameters.Add("@FileExtenstion", entity.FileExtenstion);
                parameters.Add("@DisplayDate", entity.DisplayDate);
                parameters.Add("@SessionUser", "");
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertDahboardImages", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > InsertDahboardImages");
            }
            return returnType;
        }

        public async Task<ReturnType<string>> DeleteDahboardImages(string DocId)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentDetailId", DocId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteDahboardImages", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserRepository > InsertDahboardImages");
            }
            return returnType;
        }



    }
}
