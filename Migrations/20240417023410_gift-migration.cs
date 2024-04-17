using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoveLink.Migrations
{
    public partial class giftmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceUserId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Emoji = table.Column<string>(type: "text", nullable: true),
                    DateSet = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Viewed = table.Column<bool>(type: "boolean", nullable: true),
                    LinkToSource = table.Column<string>(type: "text", nullable: true),
                    ReceivingUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gifts_Users_ReceivingUserId",
                        column: x => x.ReceivingUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gifts_Users_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Gifts",
                columns: new[] { "Id", "DateSet", "Description", "Emoji", "LinkToSource", "ReceivingUserId", "SourceUserId", "Title", "Viewed" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 21, 34, 10, 29, DateTimeKind.Local).AddTicks(9627), "Your partner poked you, and are thinkning about you.", "🎁", "https://example.com/gift", null, 1, "Poke", false },
                    { 2, new DateTime(2024, 4, 16, 21, 34, 10, 29, DateTimeKind.Local).AddTicks(9632), "Your Partner send you a warm hug!", "💝", "https://example.com/surprise", null, 2, "Hug", false }
                });

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateEntered",
                value: new DateTime(2024, 4, 16, 21, 34, 10, 28, DateTimeKind.Local).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateEntered",
                value: new DateTime(2024, 4, 16, 21, 34, 10, 28, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeSet",
                value: new DateTime(2024, 4, 16, 21, 34, 10, 29, DateTimeKind.Local).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "MyMoods",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeSet",
                value: new DateTime(2024, 4, 16, 21, 34, 10, 29, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSet",
                value: new DateTime(2024, 4, 16, 21, 34, 10, 29, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSet",
                value: new DateTime(2024, 4, 16, 21, 34, 10, 29, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_ReceivingUserId",
                table: "Gifts",
                column: "ReceivingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_SourceUserId",
                table: "Gifts",
                column: "SourceUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gifts");

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
    }
}
