using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamTrace.Models
{
    public class ContentDetail:Base
    {
        public int? ContentId { get; set; }
        [ForeignKey("ContentId")]
        public Content? Content { get; set; }
        public int? SpectificationId { get; set; }
        [ForeignKey("SpectificationId")]
        public Spectification? Spectification { get; set;}
        public string? Value { get; set; }
        public int? Status { get; set; }

        public string? Trailer { get; set; }
        public string? FullVideo { get; set; }
    }
}
