using Application.BankAccount.Query;
using Application.Common.Interface;
using Application.Home.Command;
using Application.Site.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        private readonly IConfiguration _configuration;
        public HomeController(IMediator mediator, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IHomeRepository homeRepository, IConfiguration configuration)
            : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _homeRepository = homeRepository;
            _configuration = configuration;
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

        [HttpPost]
        [Route("AddDashboardImages")]
        public async Task<ReturnType<string>> AddDashboardImages()
        {

            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var date = formCollection["date"];
                var SessionUser = formCollection["SessionUser"];

                string iconContentPath = _configuration["StoragePath:DashboardImages:Path"];
                string fileName = Guid.NewGuid().ToString();
                if (!Directory.Exists(iconContentPath))
                {
                    Directory.CreateDirectory(iconContentPath);
                }
                var extenstion = file.FileName.Split(".").LastOrDefault();
                string docName = iconContentPath + "\\" + Path.GetFileName(fileName + "." + extenstion);

                using (FileStream stream = new FileStream(Path.Combine(docName), FileMode.Create))
                    file.CopyTo(stream);

                InsertDashboardImagesCommand request = new InsertDashboardImagesCommand()
                {
                    DocumentDetailId = fileName,
                    FileExtenstion = extenstion,
                    DisplayDate = date
                };

                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > AddSites");
            }
            return returnType;
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
