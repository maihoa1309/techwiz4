using System.ComponentModel.DataAnnotations;

namespace StreamTrace.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public string? CreatedUser { get; set; }

        public DateTime? CreatedTime { get; set; }
        public string? UpdatedUser { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public bool? IsDeleted { get; set; }
        public string? DeletedUser { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
