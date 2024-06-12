using Application.AccountDetails.Command;
using Application.Common.Interface;
using Application.LoginSgnup.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiProject.API.Services;

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
        public LoginSignupController(IMediator mediator, ILogger<LoginSignupController> logger, IHttpContextAccessor httpContextAccessor, ILoginSignupRepository loginSignupRepository, ITokenService tokenService) //: base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _loginSignupRepository = loginSignupRepository;
            _tokenService = tokenService;
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at LoginSignupController > Generate_Otp");
            }
            return returnType;
        }



    }
}
