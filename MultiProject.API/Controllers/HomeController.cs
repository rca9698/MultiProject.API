using Application.BankAccount.Query;
using Application.Common.Interface;
using Application.Home.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(IMediator mediator, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IHomeRepository homeRepository)
            : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _homeRepository = homeRepository;
        }

        [HttpGet]
        [Route("GetDashboardImages")]
        public async Task<ReturnType<DashboardImages>> GetDashboardImages()
        {
            ReturnType<DashboardImages> res = new ReturnType<DashboardImages>();
            try
            {
                res = await _homeRepository.GetDashboardImages();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at HomeController > GetDashboardImages");
            }
            return res;
        }

        [HttpPost]
        [Route("InsertDashboardImages")]
        public async Task<ReturnType<string>> InsertDashboardImages(InsertDashboardImagesCommand obj)
        {
            ReturnType<string> res = new ReturnType<string>();
            try
            {
                res = await _homeRepository.InsertDashboardImages(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at HomeController > InsertDashboardImages");
            }
            return res;
        }

        [HttpGet]
        [Route("DeleteDahboardImages/{DocId}")]
        public async Task<ReturnType<string>> DeleteDahboardImages(string DocId)
        {
            ReturnType<string> res = new ReturnType<string>();
            try
            {
                res = await _homeRepository.DeleteDahboardImages(DocId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at HomeController > InsertDahboardImages");
            }
            return res;
        }
    }
}
