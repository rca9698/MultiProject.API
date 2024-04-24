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




        [HttpPost]
        [Route("DeleteAdminBankAccount")]
        public async Task<ReturnType<string>> DeleteAdminBankAccount(DeleteAdminBankAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > DeleteAdminBankAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddUpdateAdminBankAccount")]
        public async Task<ReturnType<string>> AddUpdateAdminBankAccount(AddUpdateAdminBankAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > AddUpdateAdminBankAccount");
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
                GetAdminBankAccountsQuery request = new GetAdminBankAccountsQuery();
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > GetAdminBankAccounts");
            }
            return returnType;
        }

        [HttpGet]
        [Route("SetDefaultAdminBankAccount/{sessionUser}/{BankDetailID}")]
        public async Task<ReturnType<string>> SetDefaultAdminBankAccount(long sessionUser, long BankDetailID)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _bankAccountRepository.SetDefaultAdminBankAccount(sessionUser, BankDetailID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > SetDefaultBankAccount");
            }
            return returnType;
        }


        [HttpPost]
        [Route("AddUpdateAdminUpiAccount")]
        public async Task<ReturnType<string>> AddUpdateAdminUpiAccount(AddUpdateAdminUpiAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _bankAccountRepository.AddUpdateAdminUpiAccount(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > AddUpdateAdminUpiAccount");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetAdminUpiAccount")]
        public async Task<ReturnType<BankDetails>> GetAdminUpiAccount()
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                returnType = await _bankAccountRepository.GetAdminUpiAccount();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > GetAdminUpiAccount");
            }
            return returnType;
        }

        [HttpGet]
        [Route("SetDefaultAdminUpiAccount/{sessionUser}/{UpiID}")]
        public async Task<ReturnType<string>> SetDefaultAdminUpiAccount(long sessionUser, long UpiID)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _bankAccountRepository.SetDefaultAdminUpiAccount(sessionUser, UpiID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > SetDefaultAdminUpiAccount");
            }
            return returnType;
        }

        [HttpGet]
        [Route("DeleteAdminUpiAccount/{sessionUser}/{UpiId}")]
        public async Task<ReturnType<string>> DeleteAdminUpiAccount(long sessionUser, long UpiId)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _bankAccountRepository.DeleteAdminUpiAccount(sessionUser, UpiId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > DeleteAdminUpiAccount");
            }
            return returnType;
        }




        [HttpGet]
        [Route("AddUpdateAdminQRCode/{SessionUser}/{UserName}")]
        public async Task<ReturnType<string>> AddUpdateAdminQRCode(long SessionUser,string UserName)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _bankAccountRepository.AddUpdateAdminQRCode(SessionUser,UserName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > AddUpdateAdminQRCode");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetAdminQRCode")]
        public async Task<ReturnType<BankDetails>> GetAdminQRCode()
        {
            ReturnType<BankDetails> returnType = new ReturnType<BankDetails>();
            try
            {
                returnType = await _bankAccountRepository.GetAdminQRCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at BankAccountController > GetAdminQRCode");
            }
            return returnType;
        }


    }
}
