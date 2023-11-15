using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class JournalMoodTag
    {
        public int Id { get; set; } // Primary key
        required
        public int JournalId { get; set; }// Foreign key to Journal
        [ForeignKey("JournalId")]
        public int MoodTagId { get; set; } // Foreign key to MoodTag
        [ForeignKey("MoodTagId")]
        public Journal? Journal { get; set; }
        public MoodTag? MoodTag { get; set; }
    }
}
