﻿// <auto-generated />
using System;
using LoveLink;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoveLink.Migrations
{
    [DbContext(typeof(LoveLinkDbContext))]
    partial class LoveLinkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LoveLink.Models.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateEntered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Entry")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("integer");

                    b.Property<string>("PartnerUid")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Visibility")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Journals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateEntered = new DateTime(2023, 11, 18, 9, 30, 42, 653, DateTimeKind.Local).AddTicks(1332),
                            Entry = "This is the first entry.",
                            Name = "Mark's first Journal Entry",
                            PartnerId = 2,
                            PartnerUid = "efg789hij0",
                            UserId = 1,
                            Visibility = "Public"
                        },
                        new
                        {
                            Id = 2,
                            DateEntered = new DateTime(2023, 11, 18, 9, 30, 42, 653, DateTimeKind.Local).AddTicks(1391),
                            Entry = "This is Alex's entry.",
                            Name = "Alex's first Journal Entry",
                            PartnerId = 1,
                            PartnerUid = "123abc456d",
                            UserId = 2,
                            Visibility = "Private"
                        });
                });

            modelBuilder.Entity("LoveLink.Models.JournalMoodTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("JournalId")
                        .HasColumnType("integer");

                    b.Property<int>("MoodTagId")
                        .HasColumnType("integer");

                    b.Property<int?>("MoodTagId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.HasIndex("MoodTagId");

                    b.HasIndex("MoodTagId1");

                    b.ToTable("JournalMoodTag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            JournalId = 1,
                            MoodTagId = 1
                        },
                        new
                        {
                            Id = 3,
                            JournalId = 1,
                            MoodTagId = 1
                        },
                        new
                        {
                            Id = 4,
                            JournalId = 2,
                            MoodTagId = 2
                        });
                });

            modelBuilder.Entity("LoveLink.Models.MoodTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MoodTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Feeling joyful and content",
                            Name = "Happy"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Feeling enthusiastic and eager",
                            Name = "Excited"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Feeling peaceful and relaxed",
                            Name = "Calm"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Engaging in deep thought or meditation",
                            Name = "Reflective"
                        });
                });

            modelBuilder.Entity("LoveLink.Models.MyMood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateTimeSet")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Mood")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("integer");

                    b.Property<string>("PartnerUid")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("MyMoods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTimeSet = new DateTime(2023, 11, 18, 9, 30, 42, 654, DateTimeKind.Local).AddTicks(3014),
                            Mood = "Happy",
                            Notes = "Feeling great today!",
                            PartnerId = 2,
                            PartnerUid = "efg789hij0",
                            UserId = 1,
                            UserName = "Mark"
                        },
                        new
                        {
                            Id = 2,
                            DateTimeSet = new DateTime(2023, 11, 18, 9, 30, 42, 654, DateTimeKind.Local).AddTicks(3035),
                            Mood = "Calm",
                            Notes = "Taking it easy.",
                            PartnerId = 1,
                            PartnerUid = "123abc456d",
                            UserId = 2,
                            UserName = "Alex"
                        });
                });

            modelBuilder.Entity("LoveLink.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateSet")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LinkToSource")
                        .HasColumnType("text");

                    b.Property<int?>("ReceivingUserId")
                        .HasColumnType("integer");

                    b.Property<string>("ReceivingUserName")
                        .HasColumnType("text");

                    b.Property<int?>("SourceUserId")
                        .HasColumnType("integer");

                    b.Property<string>("SourceUserName")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<bool?>("Viewed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ReceivingUserId");

                    b.HasIndex("SourceUserId");

                    b.ToTable("Notifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateSet = new DateTime(2023, 11, 18, 9, 30, 42, 655, DateTimeKind.Local).AddTicks(184),
                            LinkToSource = "https://example.com/message",
                            ReceivingUserId = 2,
                            ReceivingUserName = "Alex",
                            SourceUserId = 1,
                            SourceUserName = "Mark",
                            Title = "Mark posted a journal entry",
                            Viewed = false
                        },
                        new
                        {
                            Id = 2,
                            DateSet = new DateTime(2023, 11, 18, 9, 30, 42, 655, DateTimeKind.Local).AddTicks(201),
                            LinkToSource = "https://example.com/friend-request",
                            ReceivingUserId = 1,
                            ReceivingUserName = "Mark",
                            SourceUserId = 2,
                            SourceUserName = "Alex",
                            Title = "Alex set Their Mood To 'Happy'",
                            Viewed = false
                        });
                });

            modelBuilder.Entity("LoveLink.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("AnniversaryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PartnerCode")
                        .HasColumnType("integer");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("integer");

                    b.Property<string>("PartnerUid")
                        .HasColumnType("text");

                    b.Property<int?>("PartnerUserId")
                        .HasColumnType("integer");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("text");

                    b.Property<string>("UID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PartnerUserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 25,
                            AnniversaryDate = new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bio = "Hi im Mark!",
                            Gender = "He/Him",
                            Name = "Mark",
                            PartnerId = 2,
                            PartnerUid = "efg789hij0",
                            ProfilePhoto = "fakeLinkToFile",
                            UID = "123abc456d"
                        },
                        new
                        {
                            Id = 2,
                            Age = 24,
                            AnniversaryDate = new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bio = "Hi im Alex!",
                            Gender = "She/Her",
                            Name = "Alex",
                            PartnerId = 1,
                            PartnerUid = "123abc456d",
                            ProfilePhoto = "fakeLinkToFile",
                            UID = "efg789hij0"
                        });
                });

            modelBuilder.Entity("LoveLink.Models.Journal", b =>
                {
                    b.HasOne("LoveLink.Models.User", "User")
                        .WithMany("Journals")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LoveLink.Models.JournalMoodTag", b =>
                {
                    b.HasOne("LoveLink.Models.Journal", null)
                        .WithMany()
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoveLink.Models.Journal", "Journal")
                        .WithMany()
                        .HasForeignKey("MoodTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoveLink.Models.MoodTag", null)
                        .WithMany()
                        .HasForeignKey("MoodTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoveLink.Models.MoodTag", "MoodTag")
                        .WithMany()
                        .HasForeignKey("MoodTagId1");

                    b.Navigation("Journal");

                    b.Navigation("MoodTag");
                });

            modelBuilder.Entity("LoveLink.Models.MyMood", b =>
                {
                    b.HasOne("LoveLink.Models.User", "User")
                        .WithOne("MyMood")
                        .HasForeignKey("LoveLink.Models.MyMood", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LoveLink.Models.Notification", b =>
                {
                    b.HasOne("LoveLink.Models.User", "ReceivingUser")
                        .WithMany()
                        .HasForeignKey("ReceivingUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LoveLink.Models.User", "SourceUser")
                        .WithMany("Notifications")
                        .HasForeignKey("SourceUserId");

                    b.Navigation("ReceivingUser");

                    b.Navigation("SourceUser");
                });

            modelBuilder.Entity("LoveLink.Models.User", b =>
                {
                    b.HasOne("LoveLink.Models.User", "PartnerUser")
                        .WithMany()
                        .HasForeignKey("PartnerUserId");

                    b.Navigation("PartnerUser");
                });

            modelBuilder.Entity("LoveLink.Models.User", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("MyMood");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
