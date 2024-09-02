using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarani.Domain.Request
{
    public class SearchContentRequest
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public int? HeaderId { get; set; }
        public int? ModuleId { get; set; }
        public string? Permalink { get; set; }
    }
}
