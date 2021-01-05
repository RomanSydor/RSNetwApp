using Microsoft.EntityFrameworkCore.Migrations;

namespace RSNetwApp.Repositories.Migrations
{
    public partial class uniqueAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "CredentialsEntities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CredentialsEntities_Username",
                table: "CredentialsEntities",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CredentialsEntities_Username",
                table: "CredentialsEntities");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "CredentialsEntities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
