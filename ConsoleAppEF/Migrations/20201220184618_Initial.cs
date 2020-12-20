using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppEF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password" },
                values: new object[] { new Guid("197d56c1-b203-4a75-8234-baff9bef3f1c"), 30, "Mubeen@gmail.com", "Mubeen", "123123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password" },
                values: new object[] { new Guid("71e1461a-c50d-4594-a86a-9305045e6ea2"), 15, "Tahir@gmail.com", "Tahir", "321321" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password" },
                values: new object[] { new Guid("e735dbeb-c68b-4b42-aa11-79a017dfa93d"), 25, "Cheema@gmail.com", "Cheema", "123321" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
