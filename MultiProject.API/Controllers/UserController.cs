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
    public class UserController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public UserController(IMediator mediator, ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<ReturnType<UserDetail>> GetUsers(GetUsersQuery request)
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > GetUsers");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ReturnType<string>> AddUser(AddUserCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > AddUsers");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<ReturnType<string>> DeleteUser(DeleteUserCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > DeleteUsers");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ReturnType<string>> UpdateUser(UpdateUserCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > UpdateUser");
            }
            return returnType;
        }
    }
}
