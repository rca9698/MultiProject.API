using Application.AccountDetails.Command;
using Application.Site.Command;
using Application.Site.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SiteController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SiteController(IMediator mediator, ILogger<SiteController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , IWebHostEnvironment hostingEnvironment) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("GetSites")]
        public async Task<ReturnType<SiteDetail>> GetSites(ListSitesCommand request)
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("ViewThisSiteDetails")]
        public async Task<ReturnType<IDDetail>> ViewThisSiteDetails(ViewThisSiteDetailsQuery request)
        {
            ReturnType<IDDetail> returnType = new ReturnType<IDDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > ViewThisSiteDetails");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddSite")]
        public async Task<ReturnType<string>> AddSite(AddSiteCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > AddSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddSiteDetail")]
        public async Task<ReturnType<string>> AddSiteDetail()
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var SiteId = formCollection["SiteId"];
                var SiteName = formCollection["SiteName"];
                var SiteURL = formCollection["SiteURL"];
                var SessionUser = formCollection["SessionUser"];

                string iconContentPath = _configuration["StoragePath:SiteIcon:Path"];
                string fileName = Guid.NewGuid().ToString();
                if (!Directory.Exists(iconContentPath))
                {
                    Directory.CreateDirectory(iconContentPath);
                }
                var extenstion = file.FileName.Split(".").LastOrDefault();
                string docName = iconContentPath + "\\" + Path.GetFileName(fileName + "." + extenstion);

                using (FileStream stream = new FileStream(Path.Combine(docName), FileMode.Create))
                    file.CopyTo(stream);

                AddSiteCommand request = new AddSiteCommand()
                {
                    DocumentDetailId = fileName,
                    ImageName = file.FileName,
                    ImageSize = file.Length.ToString(),
                    SiteName = SiteName,
                    SiteURL = SiteURL,
                    FileExtenstion = extenstion,
                    SessionUser = Convert.ToInt64(SessionUser)
                };

                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > AddSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteSite")]
        public async Task<ReturnType<string>> DeleteSite(DeleteSiteCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > DeleteSites");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateSite")]
        public async Task<ReturnType<string>> UpdateSite(UpdateSiteCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > UpdateSite");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateSiteDetail")]
        public async Task<ReturnType<string>> UpdateSiteDetail()
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var SiteName = formCollection.Keys.FirstOrDefault(x => x == "SiteName");
                var SiteURL = formCollection.Keys.FirstOrDefault(x => x == "SiteURL");
                var SessionUser = formCollection.Keys.FirstOrDefault(x => x == "SessionUser");
                var SiteId = formCollection.Keys.FirstOrDefault(x => x == "SiteId");

                string iconContentPath = _configuration["StoragePath:SiteIcon:Path"];
                string fileName = Guid.NewGuid().ToString();
                if (!Directory.Exists(iconContentPath))
                {
                    Directory.CreateDirectory(iconContentPath);
                }
                var extenstion = file.FileName.Split(".").LastOrDefault();
                string docName = iconContentPath + "\\" + Path.GetFileName(fileName + "." + extenstion);

                using (FileStream stream = new FileStream(Path.Combine(docName), FileMode.Create))
                    file.CopyTo(stream);

                UpdateSiteCommand request = new UpdateSiteCommand()
                {
                    DocumentDetailId = docName,
                    ImageName = file.FileName,
                    ImageSize = file.Length.ToString(),
                    SiteName = SiteName,
                    SiteURL = SiteURL,
                    FileExtenstion = extenstion,
                    SessionUser = Convert.ToInt64(SessionUser),
                    SiteId = Convert.ToInt32(SiteId)
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
        [Route("GetUserListSiteById/{userId}")]
        public async Task<ReturnType<SiteDetail>> GetUserListSiteById(long userId)
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                GetUserListSiteByIdQuery request = new GetUserListSiteByIdQuery()
                {
                    UserId = userId
                };
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetUserListSiteById");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetUserListSites")]
        public async Task<ReturnType<SiteDetail>> GetUserListSites()
        {
            ReturnType<SiteDetail> returnType = new ReturnType<SiteDetail>();
            try
            {
                GetUserListSiteByIdQuery request = new GetUserListSiteByIdQuery();
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at SiteController > GetUserListSites");
            }
            return returnType;
        }

    }
}
