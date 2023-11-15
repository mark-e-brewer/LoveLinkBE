namespace LoveLink.Models
{
    public class MoodTag
    {
        public int? Id { get; set; }
        required
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Journal>? Journals { get; set; }
    }
}
