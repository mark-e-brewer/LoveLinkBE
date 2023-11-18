using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class PkAutoGenerateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalMoodTag",
                table: "JournalMoodTag");

            migrationBuilder.DeleteData(
                table: "JournalMoodTag",
                keyColumns: new[] { "JournalId", "MoodTagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JournalMoodTag",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MoodTagId1",
                table: "JournalMoodTag",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalMoodTag",
                table: "JournalMoodTag",
                column: "Id");

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
                    { 1, new DateTime(2023, 11, 17, 20, 21, 21, 178, DateTimeKind.Local).AddTicks(3711), "This is the first entry.", "Mark's first Journal Entry", 2, "efg789hij0", 1, "Public" },
                    { 2, new DateTime(2023, 11, 17, 20, 21, 21, 178, DateTimeKind.Local).AddTicks(3756), "This is Alex's entry.", "Alex's first Journal Entry", 1, "123abc456d", 2, "Private" }
                });

            migrationBuilder.InsertData(
                table: "MyMoods",
                columns: new[] { "Id", "DateTimeSet", "Mood", "Notes", "PartnerId", "PartnerUid", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 17, 20, 21, 21, 179, DateTimeKind.Local).AddTicks(7404), "Happy", "Feeling great today!", 2, "efg789hij0", 1, "Mark" },
                    { 2, new DateTime(2023, 11, 17, 20, 21, 21, 179, DateTimeKind.Local).AddTicks(7425), "Calm", "Taking it easy.", 1, "123abc456d", 2, "Alex" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "DateSet", "LinkToSource", "ReceivingUserId", "ReceivingUserName", "SourceUserId", "SourceUserName", "Title", "Viewed" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 17, 20, 21, 21, 180, DateTimeKind.Local).AddTicks(8288), "https://example.com/message", 2, "Alex", 1, "Mark", "Mark posted a journal entry", false },
                    { 2, new DateTime(2023, 11, 17, 20, 21, 21, 180, DateTimeKind.Local).AddTicks(8309), "https://example.com/friend-request", 1, "Mark", 2, "Alex", "Alex set Their Mood To 'Happy'", false }
                });

            migrationBuilder.InsertData(
                table: "JournalMoodTag",
                columns: new[] { "Id", "JournalId", "MoodTagId", "MoodTagId1" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 3, 1, 1, null },
                    { 4, 2, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalMoodTag_JournalId",
                table: "JournalMoodTag",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalMoodTag_MoodTagId1",
                table: "JournalMoodTag",
                column: "MoodTagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTag_Journals_MoodTagId",
                table: "JournalMoodTag",
                column: "MoodTagId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTag_MoodTags_MoodTagId1",
                table: "JournalMoodTag",
                column: "MoodTagId1",
                principalTable: "MoodTags",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTag_Journals_MoodTagId",
                table: "JournalMoodTag");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTag_MoodTags_MoodTagId1",
                table: "JournalMoodTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalMoodTag",
                table: "JournalMoodTag");

            migrationBuilder.DropIndex(
                name: "IX_JournalMoodTag_JournalId",
                table: "JournalMoodTag");

            migrationBuilder.DropIndex(
                name: "IX_JournalMoodTag_MoodTagId1",
                table: "JournalMoodTag");

            migrationBuilder.DeleteData(
                table: "JournalMoodTag",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MoodTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JournalMoodTag");

            migrationBuilder.DropColumn(
                name: "MoodTagId1",
                table: "JournalMoodTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalMoodTag",
                table: "JournalMoodTag",
                columns: new[] { "JournalId", "MoodTagId" });

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
                    { 1, new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(1881), "This is the first entry.", "Mark's first Journal Entry", 2, "efg789hij0", 1, "Public" },
                    { 2, new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(1918), "This is Alex's entry.", "Alex's first Journal Entry", 1, "123abc456d", 2, "Private" }
                });

            migrationBuilder.InsertData(
                table: "MyMoods",
                columns: new[] { "Id", "DateTimeSet", "Mood", "Notes", "PartnerId", "PartnerUid", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(7714), "Happy", "Feeling great today!", 2, "efg789hij0", 1, "Mark" },
                    { 2, new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(7731), "Calm", "Taking it easy.", 1, "123abc456d", 2, "Alex" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "DateSet", "LinkToSource", "ReceivingUserId", "ReceivingUserName", "SourceUserId", "SourceUserName", "Title", "Viewed" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 13, 22, 12, 18, 910, DateTimeKind.Local).AddTicks(4792), "https://example.com/message", 2, "Alex", 1, "Mark", "Mark posted a journal entry", false },
                    { 2, new DateTime(2023, 11, 13, 22, 12, 18, 910, DateTimeKind.Local).AddTicks(4809), "https://example.com/friend-request", 1, "Mark", 2, "Alex", "Alex set Their Mood To 'Happy'", false }
                });
        }
    }
}
