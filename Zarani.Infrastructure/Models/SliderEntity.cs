using System.ComponentModel.DataAnnotations;

namespace Zarani.Infrastructure.Models
{
    public class SliderEntity : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string WebImageUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string MobileImageUrl { get; set; }

        [MaxLength(1000)]
        public string Detail { get; set; }

        [MaxLength(500)]
        public string RedirectUrl { get; set; }
    }
}
