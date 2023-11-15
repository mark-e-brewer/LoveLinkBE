using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoodTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UID = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    ProfilePhoto = table.Column<string>(type: "text", nullable: true),
                    PartnerId = table.Column<int>(type: "integer", nullable: true),
                    PartnerUid = table.Column<string>(type: "text", nullable: true),
                    AnniversaryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PartnerCode = table.Column<int>(type: "integer", nullable: true),
                    PartnerUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_PartnerUserId",
                        column: x => x.PartnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    PartnerId = table.Column<int>(type: "integer", nullable: true),
                    PartnerUid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Entry = table.Column<string>(type: "text", nullable: true),
                    DateEntered = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Visibility = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MyMoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PartnerId = table.Column<int>(type: "integer", nullable: true),
                    PartnerUid = table.Column<string>(type: "text", nullable: true),
                    Mood = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DateTimeSet = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyMoods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceUserId = table.Column<int>(type: "integer", nullable: true),
                    SourceUserName = table.Column<string>(type: "text", nullable: true),
                    ReceivingUserId = table.Column<int>(type: "integer", nullable: true),
                    ReceivingUserName = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    DateSet = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Viewed = table.Column<bool>(type: "boolean", nullable: true),
                    LinkToSource = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_ReceivingUserId",
                        column: x => x.ReceivingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JournalMoodTag",
                columns: table => new
                {
                    JournalsId = table.Column<int>(type: "integer", nullable: false),
                    MoodTagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalMoodTag", x => new { x.JournalsId, x.MoodTagsId });
                    table.ForeignKey(
                        name: "FK_JournalMoodTag_Journals_JournalsId",
                        column: x => x.JournalsId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalMoodTag_MoodTags_MoodTagsId",
                        column: x => x.MoodTagsId,
                        principalTable: "MoodTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MoodTags",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Feeling joyful and content", "Happy" },
                    { 2, "Feeling enthusiastic and eager", "Excited" },
                    { 3, "Feeling peaceful and relaxed", "Calm" },
                    { 4, "Engaging in deep thought or meditation", "Reflective" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "AnniversaryDate", "Bio", "Gender", "Name", "PartnerCode", "PartnerId", "PartnerUid", "PartnerUserId", "ProfilePhoto", "UID" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hi im Mark!", "He/Him", "Mark", null, 2, "efg789hij0", null, "fakeLinkToFile", "123abc456d" },
                    { 2, 24, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hi im Alex!", "She/Her", "Alex", null, 1, "123abc456d", null, "fakeLinkToFile", "efg789hij0" }
                });

            migrationBuilder.InsertData(
                table: "Journals",
                columns: new[] { "Id", "DateEntered", "Entry", "Name", "PartnerId", "PartnerUid", "UserId", "Visibility" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9525), "This is the first entry.", "Mark's first Journal Entry", 2, "efg789hij0", 1, "Public" },
                    { 2, new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9563), "This is Alex's entry.", "Alex's first Journal Entry", 1, "123abc456d", 2, "Private" }
                });

            migrationBuilder.InsertData(
                table: "MyMoods",
                columns: new[] { "Id", "DateTimeSet", "Mood", "Notes", "PartnerId", "PartnerUid", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9588), "Happy", "Feeling great today!", 2, "efg789hij0", 1, "Mark" },
                    { 2, new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9592), "Calm", "Taking it easy.", 1, "123abc456d", 2, "Alex" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "DateSet", "LinkToSource", "ReceivingUserId", "ReceivingUserName", "SourceUserId", "SourceUserName", "Title", "Viewed" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 13, 22, 8, 54, 883, DateTimeKind.Local).AddTicks(7330), "https://example.com/message", 2, "Alex", 1, "Mark", "Mark posted a journal entry", false },
                    { 2, new DateTime(2023, 11, 13, 22, 8, 54, 883, DateTimeKind.Local).AddTicks(7351), "https://example.com/friend-request", 1, "Mark", 2, "Alex", "Alex set Their Mood To 'Happy'", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalMoodTag_MoodTagsId",
                table: "JournalMoodTag",
                column: "MoodTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_UserId",
                table: "Journals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMoods_UserId",
                table: "MyMoods",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceivingUserId",
                table: "Notifications",
                column: "ReceivingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SourceUserId",
                table: "Notifications",
                column: "SourceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PartnerUserId",
                table: "Users",
                column: "PartnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalMoodTag");

            migrationBuilder.DropTable(
                name: "MyMoods");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "MoodTags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
