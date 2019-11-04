using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadBugAPI.Migrations
{
    public partial class TrackInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bug",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Bug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Bug",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bug_ModifiedById",
                table: "Bug",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Bug_AspNetUsers_ModifiedById",
                table: "Bug",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bug_AspNetUsers_ModifiedById",
                table: "Bug");

            migrationBuilder.DropIndex(
                name: "IX_Bug_ModifiedById",
                table: "Bug");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bug");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Bug");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Bug");
        }
    }
}
