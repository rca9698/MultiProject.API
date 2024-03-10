using Application.DropDown.Command;
using Domain.Common;
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
        public DropDownController(IMediator mediator, ILogger<DropDownController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetTransactionType")]
        public async Task<ReturnType<bool>> GetTransactionType(TransactionTypeCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DropDownController > GetTransactionType");
            }
            return returnType;
        }

        [HttpPost]
        [Route("GetStatusType")]
        public async Task<ReturnType<bool>> GetStatusType(TransactionTypeCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DropDownController > GetStatusType");
            }
            return returnType;
        }

    }
}
