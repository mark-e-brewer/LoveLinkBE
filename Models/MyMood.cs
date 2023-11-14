namespace LoveLink.Models
{
    public class MyMood
    {
        public int? Id { get; set; }
        required
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PartnerId { get; set; }
        public int? PartnerUid { get; set; }
        public string? Mood { get; set; }
        public string? Notes { get; set; }
        public DateTime? DateTimeSet { get; set; }
        public User? User { get; set; }
    }
}
