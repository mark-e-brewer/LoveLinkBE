using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Bio { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePhoto { get; set; }
        public int? PartnerId { get; set; }
        public string? PartnerUid { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public int? PartnerCode { get; set; }
        public MyMood? MyMood { get; set; }
        public ICollection<Journal>? Journals { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public User? PartnerUser { get; set; }
    }
}
