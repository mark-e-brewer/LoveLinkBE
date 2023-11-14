using LoveLink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LoveLink
{
    public class LoveLinkDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<MyMood> MyMoods { get; set; }
        public DbSet<MoodTag> MoodTags { get; set; }
        public DbSet<Journal> Journals { get; set; }

        public LoveLinkDbContext(DbContextOptions<LoveLinkDbContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UID = "123abc456d", Name = "Mark", Age = 25, Bio = "Hi im Mark!", Gender = "He/Him", ProfilePhoto = "fakeLinkToFile", PartnerId = 2, PartnerUid = "efg789hij0", AnniversaryDate = new DateTime(2021, 3, 2), PartnerCode = null, MyMood = null, Journals = null, Notifications = null, PartnerUser = null },
                new User { Id = 2, UID = "efg789hij0", Name = "Alex", Age = 24, Bio = "Hi im Alex!", Gender = "She/Her", ProfilePhoto = "fakeLinkToFile", PartnerId = 1, PartnerUid = "123abc456d", AnniversaryDate = new DateTime(2021, 3, 2), PartnerCode = null, MyMood = null, Journals = null, Notifications = null, PartnerUser = null }
            );

            modelBuilder.Entity<Journal>().HasData(
     new Journal
     {
         Id = 1,
         UserId = 1,
         PartnerId = 2,
         PartnerUid = "efg789hij0",
         Name = "Mark's first Journal Entry",
         Entry = "This is the first entry.",
         DateEntered = DateTime.Now,
         Visibility = "Public",
         MoodTags = new List<MoodTag>
        {
            new MoodTag { UserId = 1, Name = "Happy", Description = "Feeling joyful and content" },
            new MoodTag { UserId = 1, Name = "Excited", Description = "Feeling enthusiastic and eager" }
        },
         User = null
     },
     new Journal
     {
         Id = 2,
         UserId = 2,
         PartnerId = 1,
         PartnerUid = "123abc456d",
         Name = "Alex's first Journal Entry",
         Entry = "This is Alex's entry.",
         DateEntered = DateTime.Now,
         Visibility = "Private",
         MoodTags = new List<MoodTag>
        {
            new MoodTag { UserId = 2, Name = "Calm", Description = "Feeling peaceful and relaxed" },
            new MoodTag { UserId = 2, Name = "Reflective", Description = "Engaging in deep thought or meditation" }
        },
         User = null
     }
 );

            modelBuilder.Entity<MoodTag>().HasData(
                new MoodTag { Id = 1, UserId = 1, PartnerId = 2, PartnerUid = "efg789hij0", Name = "Happy", Description = "Feeling joyful and content", JournalId = 1 },
                new MoodTag { Id = 2, UserId = 1, PartnerId = 2, PartnerUid = "efg789hij0", Name = "Excited", Description = "Feeling enthusiastic and eager", JournalId = 1 },
                new MoodTag { Id = 3, UserId = 2, PartnerId = 1, PartnerUid = "123abc456d", Name = "Calm", Description = "Feeling peaceful and relaxed", JournalId = 2 },
                new MoodTag { Id = 4, UserId = 2, PartnerId = 1, PartnerUid = "123abc456d", Name = "Reflective", Description = "Engaging in deep thought or meditation", JournalId = 2 }
);
            modelBuilder.Entity<MyMood>().HasData(
                new MyMood { Id = 1, UserId = 1, UserName = "Mark", PartnerId = 2, PartnerUid = "efg789hij0", Mood = "Happy", Notes = "Feeling great today!", DateTimeSet = DateTime.Now, User = null },
                new MyMood { Id = 2, UserId = 2, UserName = "Alex", PartnerId = 1, PartnerUid = "123abc456d", Mood = "Calm", Notes = "Taking it easy.", DateTimeSet = DateTime.Now, User = null }
);

            modelBuilder.Entity<Notification>().HasData(
                new Notification
                {
                    Id = 1,
                    SourceUserId = 1,
                    SourceUserName = "Mark",
                    ReceivingUserId = 2,
                    ReceivingUserName = "Alex",
                    Title = "Journal Entry Posted",
                    DateSet = DateTime.Now,
                    Viewed = false,
                    LinkToSource = "https://example.com/message",
                    SourceUser = null,
                    ReceivingUser = null
                },
                new Notification
                {
                    Id = 2,
                    SourceUserId = 2,
                    SourceUserName = "Alex",
                    ReceivingUserId = 1,
                    ReceivingUserName = "Mark",
                    Title = "Alex Set Their Mood To 'Happy'",
                    DateSet = DateTime.Now,
                    Viewed = false,
                    LinkToSource = "https://example.com/friend-request",
                    SourceUser = null,
                    ReceivingUser = null
                }
            );
        }

    }
}
