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
        [Route("GetIDs")]
        public async Task<ReturnType<IDDetail>> GetIDs(GetIDsQuery request)
        {
            ReturnType<IDDetail> returnType = new ReturnType<IDDetail>();
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
        [Route("IDRequestList")]
        public async Task<ReturnType<IDRequest>> IDRequestList(IDRequestListQuery request)
        {
            ReturnType<IDRequest> returnType = new ReturnType<IDRequest>();
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
        [Route("IDRequestDetails/{AccountRequestId}")]
        public async Task<ReturnType<IDRequest>> IDRequestDetails(long AccountRequestId)
        {
            ReturnType<IDRequest> returnType = new ReturnType<IDRequest>();
            try
            {
                IDRequestDetailsQuery request = new IDRequestDetailsQuery()
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
        public async Task<ReturnType<IDRequest>> RejectedRequestList(IDRequestListQuery request)
        {
            ReturnType<IDRequest> returnType = new ReturnType<IDRequest>();
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
        [Route("AddID")]
        public async Task<ReturnType<string>> AddID(AddIDCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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
        [Route("AddIDRequest")]
        public async Task<ReturnType<string>> AddIDRequest(AddIDRequestCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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
        [Route("DeleteIDRequest")]
        public async Task<ReturnType<string>> DeleteIDRequest(DeleteIDRequestCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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
    
        [HttpPost]
        [Route("DeleteID")]
        public async Task<ReturnType<string>> DeleteID(DeleteIDCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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


        [HttpPost]
        [Route("ListIDChangePassword")]
        public async Task<ReturnType<IDDetail>> ListIDChangePassword(ListIDChangePasswordQuery request)
        {
            ReturnType<IDDetail> returnType = new ReturnType<IDDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > ListIDChangePassword");
            }
            return returnType;
        }

        [HttpPost]
        [Route("ListIDCloseRequest")]
        public async Task<ReturnType<IDDetail>> ListIDCloseRequest(ListIDCloseRequestCommand request)
        {
            ReturnType<IDDetail> returnType = new ReturnType<IDDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > ListIDCloseRequest");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddChangeIDPassword")]
        public async Task<ReturnType<string>> AddChangeIDPassword(AddChangeIDPasswordCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AddChangeIDPassword");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddCloseID")]
        public async Task<ReturnType<string>> AddCloseID(AddCloseIDCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AddCloseID");
            }
            return returnType;
        }

        [HttpPost]
        [Route("ConfirmChangeIDPassword")]
        public async Task<ReturnType<string>> ConfirmChangeIDPassword(ConfirmChangeIDPasswordCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > ConfirmChangeIDPassword");
            }
            return returnType;
        }

        [HttpPost]
        [Route("ConfirmCloseID")]
        public async Task<ReturnType<string>> ConfirmCloseID(ConfirmCloseIDCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > ConfirmCloseID");
            }
            return returnType;
        }

    }
}
