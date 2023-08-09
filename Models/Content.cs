
using System.ComponentModel.DataAnnotations;

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

    }
}
