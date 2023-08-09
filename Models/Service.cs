using System.ComponentModel.DataAnnotations;

namespace StreamTrace.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string? Url_register { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
    }
}
