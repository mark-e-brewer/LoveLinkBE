using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class AddProfilePhotoToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 12, 16, 19, 4, 23, 696, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 12, 16, 19, 4, 23, 696, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 12, 16, 19, 4, 23, 696, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 12, 16, 19, 4, 23, 696, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 12, 16, 19, 4, 23, 697, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 12, 16, 19, 4, 23, 697, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                table: "Users",
                type: "varchar(255)", // Specify the appropriate length
                nullable: true);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 12, 16, 18, 34, 35, 2, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 12, 16, 18, 34, 35, 2, DateTimeKind.Local).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 12, 16, 18, 34, 35, 3, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 12, 16, 18, 34, 35, 3, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 12, 16, 18, 34, 35, 4, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 12, 16, 18, 34, 35, 4, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "Users");
        }
    }
}
