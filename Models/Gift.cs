using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class Gift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SourceUserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Emoji { get; set; }
        public DateTime? DateSet { get; set; }
        public bool? Viewed { get; set; }
        public string? LinkToSource { get; set; }
        public User? ReceivingUser { get; set; }
        public User?    SourceUser { get; set; }
    }
}
