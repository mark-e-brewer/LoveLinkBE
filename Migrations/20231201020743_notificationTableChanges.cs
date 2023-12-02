using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class notificationTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceUserName",
                table: "Notifications",
                newName: "MoodSet");

            migrationBuilder.RenameColumn(
                name: "ReceivingUserName",
                table: "Notifications",
                newName: "JournalTitle");

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 30, 20, 7, 42, 902, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 30, 20, 7, 42, 902, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 30, 20, 7, 42, 903, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 30, 20, 7, 42, 903, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSet", "JournalTitle", "MoodSet" },
                values: new object[] { new DateTime(2023, 11, 30, 20, 7, 42, 904, DateTimeKind.Local).AddTicks(109), "Been a Long Day", null });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateSet", "JournalTitle", "MoodSet" },
                values: new object[] { new DateTime(2023, 11, 30, 20, 7, 42, 904, DateTimeKind.Local).AddTicks(128), null, "Happy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoodSet",
                table: "Notifications",
                newName: "SourceUserName");

            migrationBuilder.RenameColumn(
                name: "JournalTitle",
                table: "Notifications",
                newName: "ReceivingUserName");

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 30, 16, 44, 12, 606, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 30, 16, 44, 12, 606, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 30, 16, 44, 12, 607, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 30, 16, 44, 12, 607, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateSet", "ReceivingUserName", "SourceUserName" },
                values: new object[] { new DateTime(2023, 11, 30, 16, 44, 12, 608, DateTimeKind.Local).AddTicks(434), "Alex", "Mark" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateSet", "ReceivingUserName", "SourceUserName" },
                values: new object[] { new DateTime(2023, 11, 30, 16, 44, 12, 608, DateTimeKind.Local).AddTicks(451), "Mark", "Alex" });
        }
    }
}
