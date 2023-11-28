using System.ComponentModel.DataAnnotations.Schema;

namespace LoveLink.Models
{
    public class JournalMoodTag
    {
        [ForeignKey("Journal")]
        public int JournalId { get; set; }

        [ForeignKey("MoodTag")]
        public int MoodTagId { get; set; }

        public Journal Journal { get; set; }

        public MoodTag MoodTag { get; set; }
    }
}
