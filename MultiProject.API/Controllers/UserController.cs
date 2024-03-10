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
        public UserController(IMediator mediator, ILogger<UserController> logger)
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
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > GetUsers");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ReturnType<bool>> AddUser(AddUserCommand request)
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
        [Route("DeleteUser")]
        public async Task<ReturnType<bool>> DeleteUser(DeleteUserCommand request)
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

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ReturnType<bool>> UpdateUser(UpdateUserCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at UserController > UpdateUser");
            }
            return returnType;
        }
    }
}
