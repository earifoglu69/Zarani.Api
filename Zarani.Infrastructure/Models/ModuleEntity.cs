using System.ComponentModel.DataAnnotations.Schema;

namespace Zarani.Infrastructure.Models
{
    [Table("Modules")]
    public class ModuleEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
