using Application.AccountDetails.Command;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSignupController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginSignupController> _logger;
        public LoginSignupController(IMediator mediator, ILogger<LoginSignupController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ReturnType<bool>> Login(AddAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
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
        public async Task<ReturnType<bool>> Signup(AddAccountCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
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
