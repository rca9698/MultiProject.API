using Application.BankAccount.Query;
using Application.Common.Interface;
using Application.Home.Command;
using Application.Site.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

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
                var path = _configuration["StoragePath:DashboardImages:Path"];
                var apiUri = _configuration["ApiConfigs:MultilogDocument:Uri"];

                string fileName = Guid.NewGuid().ToString(); 
                var extenstion = file.FileName.Split(".").LastOrDefault();  
                
                byte[] fileBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                using (var client = new HttpClient())
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        // Read the file data
                        var fileContent = new ByteArrayContent(fileBytes);

                        // Add the file content to the multipart form data
                        formData.Add(fileContent, "file", fileName + "." + extenstion);
                        formData.Add(new StringContent(path), "path");

                        // API endpoint URL
                        var apiUrl = $"{apiUri}api/Document/AddDocument/";

                        // Send the request and get the response asynchronously
                        var response = await client.PostAsync(apiUrl, formData);

                        // Ensure the response is successful
                        response.EnsureSuccessStatusCode();

                        // Return the response content as a string
                        var dd = await response.Content.ReadAsStringAsync();
                    }
                }


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
