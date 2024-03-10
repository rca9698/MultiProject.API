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
        public SiteController(IMediator mediator, ILogger<SiteController> logger)
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
        [Route("AddSite")]
        public async Task<ReturnType<bool>> AddSite(AddSiteCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
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
        public async Task<ReturnType<bool>> DeleteSite(DeleteSiteCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
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
        public async Task<ReturnType<bool>> UpdateSite(UpdateSiteCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
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
    }
}
