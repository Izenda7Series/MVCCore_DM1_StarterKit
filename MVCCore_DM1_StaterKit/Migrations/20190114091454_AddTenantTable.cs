using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCoreStarterKit.Migrations
{
    public partial class AddTenantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Tenant_Id",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Tenant_Id",
                table: "AspNetUsers",
                column: "Tenant_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenant_Tenant_Id",
                table: "AspNetUsers",
                column: "Tenant_Id",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenant_Tenant_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Tenant_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tenant_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
