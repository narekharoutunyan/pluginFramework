using System.ComponentModel.DataAnnotations;

namespace PluginFramework.Models
{
    public class UploadImageModel
    {
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public List<string> Effects { get; set; }

        [Required]
        public double Radius { get; set; }

        [Required]
        public double Size { get; set; }
    }
}
