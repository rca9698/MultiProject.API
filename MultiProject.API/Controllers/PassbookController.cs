using Application.BankAccount.Query;
using Application.Common.Interface;
using Application.Passbook.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassbookController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PassbookController> _logger;
        public PassbookController(IMediator mediator, ILogger<PassbookController> logger, IHttpContextAccessor httpContextAccessor) 
            : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetPassbookHistory")]
        public async Task<ReturnType<PassbookDetailModel>> GetPassbookHistory(GetPassbookHistoryQuery request)
        {
            ReturnType<PassbookDetailModel> returnType = new ReturnType<PassbookDetailModel>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at PassbookController > GetPassbookHistory");
            }
            return returnType;
        }

        [HttpPost]
        [Route("GetPassbookHistoryById")]
        public async Task<ReturnType<PassbookDetailModel>> GetPassbookHistoryById(GetPassbookHistoryIdQuery request)
        {
            ReturnType<PassbookDetailModel> returnType = new ReturnType<PassbookDetailModel>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at PassbookController > GetPassbookHistoryById");
            }
            return returnType;
        }
    }
}
