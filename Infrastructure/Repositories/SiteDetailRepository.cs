using Application.Common.Interface;
using Application.Site.Command;
using Application.Site.Query;
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
    public class SiteDetailRepository : DbConnector, ISiteDetailRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public SiteDetailRepository(IConfiguration configuration, ILogger<UserRepository> logger)
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<ReturnType<SiteDetail>> Getsites(ListSitesCommand entity)
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_GetSites", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteDetailRepository > Getsites");
                return getSiteList();
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> AddSite(AddSiteCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SiteName", entity.SiteName);
                parameters.Add("@SiteURL", entity.SiteURL);
                parameters.Add("@ImageName", entity.ImageName);
                parameters.Add("@DocumentDetailId", entity.DocumentDetailId);
                parameters.Add("@FileExtenstion", entity.FileExtenstion);
                parameters.Add("@ImageSize", entity.ImageSize);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateSite", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteDetailRepository > AddSite");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> DeleteSite(DeleteSiteCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SiteId", entity.SiteId);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_DeleteSite", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteDetailRepository > DeleteSite");
            }
            return returnType;
        }

        public async Task<ReturnType<bool>> UpdateSite(UpdateSiteCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SiteName", entity.SiteName);
                parameters.Add("@SiteURL", entity.SiteURL);
                parameters.Add("@SessionUser", entity.SessionUser);
                parameters.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    var res = await connection.QueryAsync<string>("USP_InsertUpdateSite", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    int returnVal = parameters.Get<int>("@ReturnVal");
                    returnType.ReturnStatus = (ReturnStatus)returnVal;
                    returnType.ReturnMessage = res.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteDetailRepository > UpdateSite");
            }
            return returnType;
        }

        public ReturnType<SiteDetail> getSiteList()
        {
            return new ReturnType<SiteDetail>()
            {
                ReturnList = new List<SiteDetail>()
                {
                    new SiteDetail()
                    {
                        SiteId = 123,
                        SiteName = "Name",
                        SiteURL = "URL",
                        SiteImg = "Imna",
                        UpdatedBy = "Name"
                    },
                    new SiteDetail()
                    {
                        SiteId = 123,
                        SiteName = "Name",
                        SiteURL = "URL",
                        SiteImg = "Imna",
                        UpdatedBy = "Name"
                    },
                    new SiteDetail()
                    {
                        SiteId = 123,
                        SiteName = "Name",
                        SiteURL = "URL",
                        SiteImg = "Imna",
                        UpdatedBy = "Name"
                    }
                },
                ReturnStatus = ReturnStatus.Success
            };
        }

    }
}
