using Application.Common.Interface;
using Application.LoginSgnup.Command;
using Application.Notification.Command;
using Application.Notification.Query;
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
    public class NotificationRepository: DbConnector, INotificationRepository
    {
        private readonly ILogger<NotificationRepository> _logger;
        public NotificationRepository(IConfiguration configuration, ILogger<NotificationRepository> logger) 
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<bool>> DeleteNotification(DeleteNotificationCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NotificationId", entity.NotificationId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteNotification", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at NotificationRepository > Login");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> InsertNotification(InsertNotificationCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NotificationDescription", entity.NotificationDescription);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertNotification", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupRepository > Login");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> UpdateNotification(UpdateNotificationCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NotificationId", entity.NotificationId);
                parameters.Add("@NotificationDescription", entity.NotificationDescription);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertNotification", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupRepository > Login");
            }
            return returnType;
        }

        public async Task<ReturnType<NotificationDetail>> GetNotifications(GetNotificationQuery entity)
        {
            ReturnType<NotificationDetail> returnType = new ReturnType<NotificationDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<NotificationDetail>("USP_GetNotifications", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnList = res.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupRepository > Login");
            }
            return returnType;
        }
    }
}
