using Microsoft.EntityFrameworkCore.Migrations;

namespace RSNetwApp.Repositories.Migrations
{
    public partial class userNameAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "CredentialsEntities",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "CredentialsEntities",
                newName: "Login");
        }
    }
}
