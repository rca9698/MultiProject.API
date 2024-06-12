using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MultiProject.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public TokenController(IConfiguration configuration, ITokenService tokenService) 
        {
            _configuration = configuration;
            _tokenService = tokenService;

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(long userId)
        {

           return Ok(_tokenService.GenerateToken(userId, ""));
        }

    }
}
