using Application.AccountDetails.Command;
using Application.LoginSgnup.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSignupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginSignupController> _logger;
        public LoginSignupController(IMediator mediator, ILogger<LoginSignupController> logger, IHttpContextAccessor httpContextAccessor) //: base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
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

        [HttpPost]
        [Route("Signup")]
        public async Task<ReturnType<string>> Signup(AddAccountCommand request)
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

    }
}
