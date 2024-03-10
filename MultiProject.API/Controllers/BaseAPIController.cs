using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        public BaseAPIController()
        {

        }
    }
}
