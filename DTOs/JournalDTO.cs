using LoveLink.Models;

namespace LoveLink.DTOs
{
    public class JournalDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PartnerId { get; set; }
        public string? PartnerUid { get; set; }
        public string? Name { get; set; }
        public string? Entry { get; set; }
        public DateTime? DateEntered { get; set; }
        public string? Visibility { get; set; }
        public ICollection<MoodTag>? MoodTags { get; set; }
    }
}
