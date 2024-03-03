using Application.AccountDetails.Command;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public AccountController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAccounts")]
        public async Task<ReturnType<bool>> GetAccounts(AddAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > GetAccounts");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<ReturnType<bool>> AddAccount(AddAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AddAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteAccount")]
        public async Task<ReturnType<bool>> DeleteAccount(DeleteAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > DeleteAccount");
            }
            return returnType;
        }
    }
}
