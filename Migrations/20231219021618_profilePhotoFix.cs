using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class profilePhotoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 12, 18, 20, 16, 18, 369, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 12, 18, 20, 16, 18, 369, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 12, 18, 20, 16, 18, 369, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 12, 18, 20, 16, 18, 369, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 12, 18, 20, 16, 18, 370, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 12, 18, 20, 16, 18, 370, DateTimeKind.Local).AddTicks(7615));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "Users");

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
        }
    }
}
