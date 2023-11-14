namespace LoveLink.Models
{
    public class MoodTag
    {
        public int? Id { get; set; }
        required
        public int? UserId { get; set; }
        public int? PartnerId { get; set; }
        public int? PartnerUid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? JournalId { get; set; }
        public ICollection<Journal>? Journals { get; set; }
    }
}
