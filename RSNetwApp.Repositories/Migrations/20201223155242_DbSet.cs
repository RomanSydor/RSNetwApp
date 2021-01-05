using Microsoft.EntityFrameworkCore.Migrations;

namespace RSNetwApp.Repositories.Migrations
{
    public partial class DbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CredentialsEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialsEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CredentialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileEntities_CredentialsEntities_CredentialsId",
                        column: x => x.CredentialsId,
                        principalTable: "CredentialsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileEntities_CredentialsId",
                table: "UserProfileEntities",
                column: "CredentialsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileEntities");

            migrationBuilder.DropTable(
                name: "CredentialsEntities");
        }
    }
}
