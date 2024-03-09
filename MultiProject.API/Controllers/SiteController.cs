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
    public class SiteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SiteController> _logger;
        public SiteController(IMediator mediator, ILogger<SiteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetSites")]
        public async Task<ReturnType<SiteDetail>> GetSites(ListSitesCommand request)
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetSites");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetSites")]
        public async Task<ReturnType<bool>> GetSites(AddSiteCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > AddSites");
            }
            return returnType;
        }

        [HttpGet]
        [Route("DeleteSites")]
        public async Task<ReturnType<bool>> DeleteSites(DeleteSiteCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > DeleteSites");
            }
            return returnType;
        }

        [HttpGet]
        [Route("UpdateSite")]
        public async Task<ReturnType<bool>> UpdateSite(UpdateSiteCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > UpdateSite");
            }
            return returnType;
        }
    }
}
