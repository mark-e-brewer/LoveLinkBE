using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class RemoveJournalMoodTagId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 17, 21, 24, 53, 529, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 17, 21, 24, 53, 529, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 17, 21, 24, 53, 531, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 17, 21, 24, 53, 531, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 17, 21, 24, 53, 531, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 17, 21, 24, 53, 531, DateTimeKind.Local).AddTicks(8730));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 17, 20, 21, 21, 178, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 17, 20, 21, 21, 178, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 17, 20, 21, 21, 179, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 17, 20, 21, 21, 179, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 17, 20, 21, 21, 180, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 17, 20, 21, 21, 180, DateTimeKind.Local).AddTicks(8309));
        }
    }
}
