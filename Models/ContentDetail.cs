using System.ComponentModel.DataAnnotations;

namespace StreamTrace.Models
{
    public class ContentDetail:Base
    {
        [Key]
        public int Id { get; set; }
    }
}
