using Application.BankAccount.Command;
using Application.BankAccount.Query;
using Application.Common.Interface;
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
        private readonly IBankAccountRepository _bankAccountRepository;
        public BankAccountController(IMediator mediator, ILogger<BankAccountController> logger, IHttpContextAccessor httpContextAccessor, IBankAccountRepository bankAccountRepository) 
            : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _bankAccountRepository = bankAccountRepository;
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

        [HttpGet]
        [Route("GetAdminBankAccounts")]
        public async Task<ReturnType<BankDetails>> GetAdminBankAccounts()
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                GetAdminBankAccountCommand request = new GetAdminBankAccountCommand();
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > GetAdminBankAccounts");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddBankAccount")]
        public async Task<ReturnType<string>> AddBankAccount(AddBankAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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

        [HttpGet]
        [Route("SetDefaultBankAccount/{sessionUser}/{BankDetailID}")]
        public async Task<ReturnType<BankDetails>> SetDefaultBankAccount(long sessionUser,long BankDetailID)
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                returnType = await _bankAccountRepository.SetDefaultBankAccount(sessionUser, BankDetailID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > SetDefaultBankAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateBankAccount")]
        public async Task<ReturnType<string>> AddBankAccount(UpdateBankAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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
        public async Task<ReturnType<string>> DeleteBankAccount(DeleteBankAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
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
