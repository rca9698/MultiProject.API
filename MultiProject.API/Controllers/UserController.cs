using Application.UserDetails.Command;
using Application.UserDetails.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ReturnType<UserDetail>> GetUsers(GetUsersQuery request)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > GetUsers");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<ReturnType<bool>> AddUsers(AddUserCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > AddUsers");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteUsers")]
        public async Task<ReturnType<bool>> DeleteUsers(DeleteUserCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > DeleteUsers");
            }
            return returnType;
        }
    }
}
