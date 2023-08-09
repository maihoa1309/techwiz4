
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamTrace.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? VIewCount { get; set; }
        public int? parentid { get; set; }
        public int? Register_type { get; set; }
        public string? Manufacture { get; set; }
        public string? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service GetService { get; set; }

    }
}
