using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        protected readonly long _userId;
        public BaseAPIController(IHttpContextAccessor httpContextAccessor)
        {
           var user = httpContextAccessor.HttpContext.User;
            _userId = Convert.ToInt64(user.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        }
    }
}
