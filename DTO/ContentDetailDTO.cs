using StreamTrace.Models;

namespace StreamTrace.DTO
{
    public class ContentDetailDTO
    {
        public Content? content { get; set; } = new Content();

        public List<ContentSpectification>? contentSpectifications { get; set; } = new List<ContentSpectification>();
    }

    public class ContentSpectification
    {
        public int? ContentId { get; set; }
        public int? SpectificationId { get; set; }
        public string? SpectificationName { get; set; }
        public List<string>? SpectificationValue { get; set; }

        
    }
}
