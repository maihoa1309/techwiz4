using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamTrace.Models
{
    public class ContentDetail:Base
    {
    
        public int SpectificationId { get; set; }
        [ForeignKey("SpectificationId")]
        public Spectification? Spectification { get; set;}
        public string? Value { get; set; }
        public string? Status { get; set; }
    }
}
