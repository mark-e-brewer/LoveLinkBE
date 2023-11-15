﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class Notification
    {
        public int? Id { get; set; }
        required
        public int? SourceUserId { get; set; }
        public string? SourceUserName { get; set; }
        public int? ReceivingUserId { get; set; }
        public string? ReceivingUserName { get; set; }
        public string? Title { get; set; }
        public DateTime? DateSet { get; set; }
        public bool? Viewed { get; set; }
        public string? LinkToSource { get; set; }
        public User? SourceUser { get; set; }
        [ForeignKey("ReceivingUserId")]  // Add this attribute
        public User? ReceivingUser { get; set; }
    }
}
