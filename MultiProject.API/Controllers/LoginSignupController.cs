using Application.AccountDetails.Command;
using Application.Common.Interface;
using Application.LoginSgnup.Command;
using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MultiProject.API.Services;
using System.Security.Cryptography;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSignupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginSignupController> _logger;
        private readonly ILoginSignupRepository _loginSignupRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;
        public LoginSignupController(IMediator mediator, ILogger<LoginSignupController> logger, IHttpContextAccessor httpContextAccessor, ILoginSignupRepository loginSignupRepository, ITokenService tokenService, IConfiguration configuration, HttpClient client) //: base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _loginSignupRepository = loginSignupRepository;
            _tokenService = tokenService;
            _configuration = configuration;
            _client = client;
        }
         
        [HttpPost]
        [Route("Login")]
        public async Task<ReturnType<UserDetail>> Login(LoginCommand request)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupController > Login");
            }
            return returnType;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login_GetToken")]
        public async Task<IActionResult> Login_GetToken(LoginCommand request)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                returnType = await _mediator.Send(request);

                if(returnType.ReturnStatus == Domain.Enum.ReturnStatus.Success)
                {
                   return Ok(_tokenService.GenerateToken(returnType.ReturnVal.UserId, returnType.ReturnVal.Otp));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupController > Login"+ ex);
                return Ok(new { status = "Failure", reason = ex.Message });
            }

            return Ok(new { status = "Failure", reason = "Invalid" });
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<ReturnType<string>> Signup(AddIDCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupController > Login");
            }
            return returnType;
        }

        [HttpGet]
        [Route("Generate_Otp/{MobileNumber}")]
        public async Task<ReturnType<Otp_Login_Model>> Generate_Otp(string MobileNumber)
        {
            ReturnType<Otp_Login_Model> returnType = new ReturnType<Otp_Login_Model>();
            try
            {

                returnType = await _loginSignupRepository.Generate_Otp(MobileNumber);

                var apiKey = returnType.ReturnVal.ApiKey;
                var otp = returnType.ReturnVal.Otp;
                var sid = returnType.ReturnVal.Sid;
                var Message = $"{returnType.ReturnVal.Message}";
                string otpResp = "success";
                var smsBaseUrl = "http://cloud.smsindiahub.in/vendorsms/pushsms.aspx";
                if(returnType.ReturnVal.role != "admin")
                {
                    var smsUrl = $"{smsBaseUrl}?APIKey={apiKey}&msisdn={MobileNumber}&sid={sid}&msg={Message}";
                    var response = await _client.GetAsync(smsUrl);
                     otpResp = await response.Content.ReadAsStringAsync();
                   
                }

                if (otpResp != null && otpResp.Contains("Failed"))
                {
                    returnType.ReturnMessage = "Failed to send OTP your number!!";
                    returnType.ReturnStatus = ReturnStatus.Failure;
                }
                else
                {
                    returnType.ReturnVal.ApiKey = null;
                    returnType.ReturnVal.Sid = null;
                    returnType.ReturnVal.Message = null;
                    returnType.ReturnMessage = "OTP sent to your number!!!";
                    returnType.ReturnStatus = ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                returnType.ReturnMessage = "Failed to send OTP your number!!!";
                returnType.ReturnStatus = ReturnStatus.Failure;

                _logger.LogError(ex, "Exception Occured at LoginSignupController > Generate_Otp");
            }
            return returnType;
        }



    }
}
