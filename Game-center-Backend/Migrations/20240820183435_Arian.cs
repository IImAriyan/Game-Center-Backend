using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_center_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Arian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gameScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameForID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    adminRole = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    age = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nationalCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    accountLocked = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    coins = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    accountBanned = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
