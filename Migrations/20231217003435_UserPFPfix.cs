using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class UserPFPfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PartnerCode", "PartnerUid", "UID" },
                values: new object[] { "123ABC", "Fe25HwCTneSDHV5QfyoLwSqPiJS2", "zb6FHsllN7Oajbgu62FuOcPgJKa2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PartnerCode", "PartnerUid", "UID" },
                values: new object[] { "123ABC", "zb6FHsllN7Oajbgu62FuOcPgJKa2", "Fe25HwCTneSDHV5QfyoLwSqPiJS2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2023, 11, 30, 20, 10, 10, 588, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2023, 11, 30, 20, 10, 10, 588, DateTimeKind.Local).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 30, 20, 10, 10, 588, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2023, 11, 30, 20, 10, 10, 588, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2023, 11, 30, 20, 10, 10, 589, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2023, 11, 30, 20, 10, 10, 589, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PartnerCode", "PartnerUid", "ProfilePhoto", "UID" },
                values: new object[] { null, "efg789hij0", "fakeLinkToFile", "123abc456d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PartnerCode", "PartnerUid", "ProfilePhoto", "UID" },
                values: new object[] { null, "123abc456d", "fakeLinkToFile", "efg789hij0" });
        }
    }
}
