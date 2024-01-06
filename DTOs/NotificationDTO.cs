using System;
using System.Text.Json.Serialization;

namespace LoveLink.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int? SourceUserId { get; set; }
        public string? SourceUserName { get; set; }
        public int? ReceivingUserId { get; set; }
        public string? ReceivingUserName { get; set; }
        public string? Title { get; set; }
        public DateTime? DateSet { get; set; }
        public bool? Viewed { get; set; }
        public string? LinkToSource { get; set; }
    }
}
