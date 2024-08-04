using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DocumentController> _logger;
        public DocumentController(IConfiguration configuration, ILogger<DocumentController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddDocument")]
        public async Task<int> AddDocument()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                string iconContentPath = formCollection["path"];

                if (!Directory.Exists(iconContentPath))
                {
                    Directory.CreateDirectory(iconContentPath);
                }
                var extenstion = file.FileName.Split(".").LastOrDefault();
                string docName = iconContentPath + "\\" + file.FileName;
                using (FileStream stream = new FileStream(Path.Combine(docName), FileMode.Create))
                    file.CopyTo(stream);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at DocumentController > AddDocument");
            }
            return 1;
        }
    }
}
