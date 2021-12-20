using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie.Core.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Actor");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MovieActor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "MovieActor");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Image");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReleaseYear",
                table: "Movie",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Actor",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
