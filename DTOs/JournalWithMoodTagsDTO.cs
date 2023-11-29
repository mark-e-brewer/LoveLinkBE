namespace LoveLink.DTOs
{
    public class JournalWithMoodTagsDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PartnerId { get; set; }
        public string? PartnerUid { get; set; }
        public string? Name { get; set; }
        public string? Entry { get; set; }
        public DateTime? DateEntered { get; set; }
        public string? Visibility { get; set; }
        public ICollection<MoodTagDTO>? MoodTags { get; set; }
    }
}
