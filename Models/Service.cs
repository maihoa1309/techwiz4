using System.ComponentModel.DataAnnotations;

namespace StreamTrace.Models
{
    public class Service :Base
    {
   
     
        public string? Url_register { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
    }
}
