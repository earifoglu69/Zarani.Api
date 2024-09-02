using System.ComponentModel.DataAnnotations;

namespace Zarani.Infrastructure.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
