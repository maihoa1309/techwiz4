
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
        public string? Manufacture { get; set; }
        public int? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? GetService { get; set; }

        public int? Status { get; set; }
        public string? ImgURL { get; set; }
        public string? Trailer { get; set; }
        public string? FullVid { get; set; }
    }
}
