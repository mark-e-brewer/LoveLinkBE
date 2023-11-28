using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class MyMood
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PartnerId { get; set; }
        public string? PartnerUid { get; set; }
        public string? Mood { get; set; }
        public string? Notes { get; set; }
        public DateTime? DateTimeSet { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
