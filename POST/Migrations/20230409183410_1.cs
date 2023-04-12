using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POST.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Personnel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_LoginId",
                table: "Personnel",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LoginId",
                table: "Customer",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Login_LoginId",
                table: "Customer",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Login_LoginId",
                table: "Personnel",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Login_LoginId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Login_LoginId",
                table: "Personnel");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_LoginId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Customer_LoginId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Customer");
        }
    }
}
