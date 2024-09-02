using System.ComponentModel.DataAnnotations.Schema;

namespace Zarani.Infrastructure.Models
{
    [Table("Products")]
    public class ProductEntity : BaseEntity
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }

    }
}
