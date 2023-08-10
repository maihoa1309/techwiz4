
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamTrace.Models
{
    public class Content:Base
    {
     
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? ViewCount { get; set; }
        public int? parentid { get; set; }
        public int? Register_type { get; set; }
        public string? Manufacture { get; set; }
        public int? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service GetService { get; set; }

    }
}
