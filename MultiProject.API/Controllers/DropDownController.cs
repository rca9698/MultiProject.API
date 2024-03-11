using Application.DropDown.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DropDownController> _logger;
        public DropDownController(IMediator mediator, ILogger<DropDownController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetTransactionType")]
        public async Task<ReturnType<DropDownDetails>> GetTransactionType(TransactionTypeCommand request)
        {
            ReturnType<DropDownDetails> returnType = new ReturnType<DropDownDetails>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DropDownController > GetTransactionType");
            }
            return returnType;
        }

        [HttpPost]
        [Route("GetStatusType")]
        public async Task<ReturnType<DropDownDetails>> GetStatusType(TransactionTypeCommand request)
        {
            ReturnType<DropDownDetails> returnType = new ReturnType<DropDownDetails>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DropDownController > GetStatusType");
            }
            return returnType;
        }

    }
}
