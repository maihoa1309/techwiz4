using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamTrace.Models
{
    public class UserSub:Base
    {
       
        public string? UserId { get; set; }
        public int? SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        public Subscription? GetSubsription { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Fee { get; set; }

    }
}
