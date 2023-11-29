using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class jmtDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalMoodTags_Journals_JournalsId",
                table: "JournalMoodTags");

            migrationBuilder.DropIndex(
                name: "IX_JournalMoodTags_JournalsId",
                table: "JournalMoodTags");

            migrationBuilder.DropColumn(
                name: "JournalsId",
                table: "JournalMoodTags");

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 28, 17, 44, 35, 761, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 28, 17, 44, 35, 761, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 28, 17, 44, 35, 761, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 28, 17, 44, 35, 761, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 28, 17, 44, 35, 762, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 28, 17, 44, 35, 762, DateTimeKind.Local).AddTicks(5842));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JournalsId",
                table: "JournalMoodTags",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 27, 20, 41, 55, 637, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 27, 20, 41, 55, 637, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 27, 20, 41, 55, 639, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 27, 20, 41, 55, 639, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 27, 20, 41, 55, 640, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 27, 20, 41, 55, 640, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.CreateIndex(
                name: "IX_JournalMoodTags_JournalsId",
                table: "JournalMoodTags",
                column: "JournalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalMoodTags_Journals_JournalsId",
                table: "JournalMoodTags",
                column: "JournalsId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
