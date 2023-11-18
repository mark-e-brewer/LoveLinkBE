using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class JournalMoodTag
    {
        public int JournalId { get; set; }
        [ForeignKey("JournalId")]
        public int MoodTagId { get; set; } // Foreign key to MoodTag
        [ForeignKey("MoodTagId")]
        public Journal? Journal { get; set; }
        public MoodTag? MoodTag { get; set; }
    }
}
