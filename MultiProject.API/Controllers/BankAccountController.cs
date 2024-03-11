using Application.BankAccount.Command;
using Application.BankAccount.Query;
using Application.Notification.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BankAccountController> _logger;
        public BankAccountController(IMediator mediator, ILogger<BankAccountController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetBankAccounts")]
        public async Task<ReturnType<BankDetails>> GetBankAccounts(GetBankAccountQuery request)
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > GetBankAccounts");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddBankAccount")]
        public async Task<ReturnType<bool>> AddBankAccount(AddBankAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > AddBankAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateBankAccount")]
        public async Task<ReturnType<bool>> AddBankAccount(UpdateBankAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > UpdateBankAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteBankAccount")]
        public async Task<ReturnType<bool>> DeleteBankAccount(DeleteBankAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > DeleteBankAccount");
            }
            return returnType;
        }
    }
}
