using Application.AccountDetails.Command;
using Application.AccountDetails.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public AccountController(IMediator mediator, ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetAccounts")]
        public async Task<ReturnType<AccountDetail>> GetAccounts(GetAccountsQuery request)
        {
            ReturnType<AccountDetail> returnType = new ReturnType<AccountDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > GetAccounts");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AccountRequestList")]
        public async Task<ReturnType<AccountRequest>> AccountRequestList(AccountRequestListQuery request)
        {
            ReturnType<AccountRequest> returnType = new ReturnType<AccountRequest>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AccountRequestList");
            }
            return returnType;
        }

        [HttpGet]
        [Route("AccountRequestDetails/{AccountRequestId}")]
        public async Task<ReturnType<AccountRequest>> AccountRequestDetails(long AccountRequestId)
        {
            ReturnType<AccountRequest> returnType = new ReturnType<AccountRequest>();
            try
            {
                AccountRequestDetailsQuery request = new AccountRequestDetailsQuery()
                {
                    AccountRequestId = AccountRequestId
                };
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AccountRequestDetails");
            }
            return returnType;
        }

        [HttpPost]
        [Route("RejectedRequestList")]
        public async Task<ReturnType<AccountRequest>> RejectedRequestList(AccountRequestListQuery request)
        {
            ReturnType<AccountRequest> returnType = new ReturnType<AccountRequest>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AccountRequestList");
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
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AddAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddAccountRequest")]
        public async Task<ReturnType<bool>> AddAccountRequest(AddAccountRequestCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                returnType = await _mediator.Send(request);
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
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > DeleteAccount");
            }
            return returnType;
        }
    }
}
