using System.ComponentModel.DataAnnotations.Schema;

namespace Zarani.Infrastructure.Models
{
    [Table("Sliders")]
    public class SliderEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string WebImageUrl { get; set; }
        public string MobileImageUrl { get; set; }
    }
}
