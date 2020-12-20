using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppEF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
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
                values: new object[] { new Guid("d96d0045-3177-4e96-a905-f61358f26cab"), 30, "Mubeen@gmail.com", "Mubeen", "123123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password" },
                values: new object[] { new Guid("b62b95f0-07cb-441f-8902-4e86065d7cdb"), 15, "Tahir@gmail.com", "Tahir", "321321" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password" },
                values: new object[] { new Guid("7aa9b9fa-2ab4-4cd2-a23b-4db16092e41a"), 25, "Cheema@gmail.com", "Cheema", "123321" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
