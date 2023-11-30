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
        public DbSet<JournalMoodTag> JournalMoodTags { get; set; }

        public LoveLinkDbContext(DbContextOptions<LoveLinkDbContext> context) : base(context) { }

        public static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

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
                    MoodTags = null

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
                    MoodTags = null
                }
            );
            modelBuilder.Entity<Journal>()
            .HasMany(j => j.MoodTags)
            .WithMany(mt => mt.Journals)
            .UsingEntity<JournalMoodTag>(
                jmt => jmt.ToTable("JournalMoodTags")
                   .HasKey("JournalId", "MoodTagId")
    );

            modelBuilder.Entity<MoodTag>().HasData(
                new MoodTag { Id = 1, Name = "Happy", Description = "Feeling joyful and content" },
                new MoodTag { Id = 2, Name = "Excited", Description = "Feeling enthusiastic and eager" },
                new MoodTag { Id = 3, Name = "Calm", Description = "Feeling peaceful and relaxed" },
                new MoodTag { Id = 4, Name = "Reflective", Description = "Engaging in deep thought or meditation" }
);
            modelBuilder.Entity<MyMood>().HasData(
                new MyMood { Id = 1, UserId = 1, UserName = "Mark", PartnerId = 2, PartnerUid = "efg789hij0", Mood = "Happy", Notes = "Feeling great today!", DateTimeSet = DateTime.Now, Users = null },
                new MyMood { Id = 2, UserId = 2, UserName = "Alex", PartnerId = 1, PartnerUid = "123abc456d", Mood = "Calm", Notes = "Taking it easy.", DateTimeSet = DateTime.Now, Users = null }
);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.ReceivingUser)
                .WithMany()
                .HasForeignKey(n => n.ReceivingUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>().HasData(new Notification
            {
                Id = 1,
                SourceUserId = 1,
                SourceUserName = "Mark",
                ReceivingUserId = 2,
                ReceivingUserName = "Alex",
                Title = "Mark posted a journal entry",
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
                    Title = "Alex set Their Mood To 'Happy'",
                    DateSet = DateTime.Now,
                    Viewed = false,
                    LinkToSource = "https://example.com/friend-request",
                    SourceUser = null,
                    ReceivingUser = null
                }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}