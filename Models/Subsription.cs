﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamTrace.Models
{
    public class Subsription:Base
    {
        [Key]
        public int Id { get; set; }
        
        public int? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? GetService { get; set; }
        public string? Subcription_type { get; set; }
        public decimal? Subcription_fee { get; set; }

    }
}
