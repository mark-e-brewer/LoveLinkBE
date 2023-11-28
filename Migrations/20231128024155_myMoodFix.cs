using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class myMoodFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyMoods_Users_UserId",
                table: "MyMoods");

            migrationBuilder.DropIndex(
                name: "IX_MyMoods_UserId",
                table: "MyMoods");

            migrationBuilder.AddColumn<int>(
                name: "MyMoodId",
                table: "Users",
                type: "integer",
                nullable: true);

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
                name: "IX_Users_MyMoodId",
                table: "Users",
                column: "MyMoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MyMoods_MyMoodId",
                table: "Users",
                column: "MyMoodId",
                principalTable: "MyMoods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MyMoods_MyMoodId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MyMoodId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MyMoodId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2023, 11, 27, 18, 12, 36, 482, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 27, 18, 12, 36, 482, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 27, 18, 12, 36, 484, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 27, 18, 12, 36, 484, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 27, 18, 12, 36, 485, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 27, 18, 12, 36, 485, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.CreateIndex(
                name: "IX_MyMoods_UserId",
                table: "MyMoods",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MyMoods_Users_UserId",
                table: "MyMoods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
