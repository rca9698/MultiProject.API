using Application.AccountDetails.Query;
using Application.Common.Interface;
using Application.Profile.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseAPIController
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileRepository _profileRepository;
        public ProfileController(ILogger<ProfileController> logger, IHttpContextAccessor httpContextAccessor, IProfileRepository profileRepository) : base(httpContextAccessor)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }


        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ReturnType<string>> ChangePassword(ChangePasswordCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _profileRepository.ChangePassword(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > ChangePassword");
            }
            return returnType;
        }

    }
}
