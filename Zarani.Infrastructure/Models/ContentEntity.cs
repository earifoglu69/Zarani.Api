using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Zarani.Infrastructure.Models
{
    public class ContentEntity : BaseEntity
    {
        [ForeignKey("Module")]
        public int? ModuleId { get; set; }
        public virtual ModuleEntity Module { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public virtual ContentEntity Parent { get; set; }

        [ForeignKey("Header")]
        public int? HeaderId { get; set; }
        public virtual ContentEntity Header { get; set; }

        public int? Order { get; set; }
        public string? Name { get; set; }
        public string Permalink { get; set; } = null!;
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; }
        public string? Field3 { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime? Date2 { get; set; }
        public DateTime? Date3 { get; set; }
        public string? Detail1 { get; set; }
        public string? Detail2 { get; set; }
        public string? Detail3 { get; set; }
        public byte? Stat1 { get; set; }
        public byte? Stat2 { get; set; }
        public int? Num1 { get; set; }
        public int? Num2 { get; set; }
        public string? File1 { get; set; }
        public string? File2 { get; set; }
        public string? File3 { get; set; }
        public string? File1AltText { get; set; }
        public string? File2AltText { get; set; }
        public string? File3AltText { get; set; }
        public string? SeoTitle { get; set; }

        public string? SeoAbstract { get; set; }

        public string? SeoKeywords { get; set; }

        public string? SeoDescription { get; set; }

        public string? OgImagePath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime Created { get; set; }


    }
}
