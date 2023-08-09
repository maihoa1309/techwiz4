using System.ComponentModel.DataAnnotations;

namespace StreamTrace.Models
{
    public class Spectification :Base
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
