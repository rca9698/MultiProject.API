using Application.AccountDetails.Command;
using Application.Site.Command;
using Application.Site.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SiteController> _logger;
        public SiteController(IMediator mediator, ILogger<SiteController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetSites")]
        public async Task<ReturnType<SiteDetail>> GetSites(ListSitesCommand request)
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("ViewThisSiteDetails")]
        public async Task<ReturnType<AccountDetail>> ViewThisSiteDetails(ViewThisSiteDetailsQuery request)
        {
            ReturnType<AccountDetail> returnType = new ReturnType<AccountDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > ViewThisSiteDetails");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddSite")]
        public async Task<ReturnType<string>> AddSite(AddSiteCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > AddSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteSite")]
        public async Task<ReturnType<string>> DeleteSite(DeleteSiteCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > DeleteSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateSite")]
        public async Task<ReturnType<string>> UpdateSite(UpdateSiteCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > UpdateSite");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetUserListSiteById/{userId}")]
        public async Task<ReturnType<SiteDetail>> GetUserListSiteById(long userId)
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                GetUserListSiteByIdQuery request = new GetUserListSiteByIdQuery()
                {
                    UserId = userId
                };
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetUserListSiteById");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetUserListSites")]
        public async Task<ReturnType<SiteDetail>> GetUserListSites()
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                GetUserListSiteByIdQuery request = new GetUserListSiteByIdQuery();
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetUserListSites");
            }
            return returnType;
        }

    }
}
