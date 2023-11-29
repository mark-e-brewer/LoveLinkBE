namespace LoveLink.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UID { get; set; }
        public int? PartnerId { get; set; }
        public string? PartnerUid { get; set; }
        public ICollection<JournalDto> Journals { get; set; }
    }
}
