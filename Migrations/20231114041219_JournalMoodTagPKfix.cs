using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class JournalMoodTagPKfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTag_Journals_JournalsId",
                table: "JournalMoodTag");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTag_MoodTags_MoodTagsId",
                table: "JournalMoodTag");

            migrationBuilder.RenameColumn(
                name: "MoodTagsId",
                table: "JournalMoodTag",
                newName: "MoodTagId");

            migrationBuilder.RenameColumn(
                name: "JournalsId",
                table: "JournalMoodTag",
                newName: "JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalMoodTag_MoodTagsId",
                table: "JournalMoodTag",
                newName: "IX_JournalMoodTag_MoodTagId");

            migrationBuilder.InsertData(
                table: "JournalMoodTag",
                columns: new[] { "JournalId", "MoodTagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 13, 22, 12, 18, 909, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 13, 22, 12, 18, 910, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 13, 22, 12, 18, 910, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTag_Journals_JournalId",
                table: "JournalMoodTag",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTag_MoodTags_MoodTagId",
                table: "JournalMoodTag",
                column: "MoodTagId",
                principalTable: "MoodTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTag_Journals_JournalId",
                table: "JournalMoodTag");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTag_MoodTags_MoodTagId",
                table: "JournalMoodTag");

            migrationBuilder.DeleteData(
                table: "JournalMoodTag",
                keyColumns: new[] { "JournalId", "MoodTagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "MoodTagId",
                table: "JournalMoodTag",
                newName: "MoodTagsId");

            migrationBuilder.RenameColumn(
                name: "JournalId",
                table: "JournalMoodTag",
                newName: "JournalsId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalMoodTag_MoodTagId",
                table: "JournalMoodTag",
                newName: "IX_JournalMoodTag_MoodTagsId");

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 13, 22, 8, 54, 882, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 13, 22, 8, 54, 883, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 13, 22, 8, 54, 883, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTag_Journals_JournalsId",
                table: "JournalMoodTag",
                column: "JournalsId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTag_MoodTags_MoodTagsId",
                table: "JournalMoodTag",
                column: "MoodTagsId",
                principalTable: "MoodTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
