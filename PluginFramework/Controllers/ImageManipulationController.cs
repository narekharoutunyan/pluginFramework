using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PluginFramework.Models;

namespace PluginFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImageManipulationController : ControllerBase
    {
        readonly IConfiguration configuration;
        readonly ApplicationContext _context;
        public ImageManipulationController(IConfiguration configuration, ApplicationContext context)
        {
            this.configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public async Task<List<string>> GetEffects()
        {
            return configuration.GetSection("Effects").Get<List<string>>();
        }

        [HttpPost]
        public async Task<bool> ManipulateImages([FromForm] List<UploadImageModel> model)
        {
            foreach (var image in model)
            {
                string path = image.Image.FileName;
                using (var fileStream = new FileStream("C:\\Users\\harou\\OneDrive\\Desktop\\Images\\" + path, FileMode.Create))
                {
                    await image.Image.CopyToAsync(fileStream);
                }

                FileModel file = new FileModel { Name = image.Image.FileName, Path = path };
                await _context.Files.AddAsync(file);
            }

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
