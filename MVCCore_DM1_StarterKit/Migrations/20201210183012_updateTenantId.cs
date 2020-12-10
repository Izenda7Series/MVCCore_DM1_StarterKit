using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCoreStarterKit.Migrations
{
    public partial class updateTenantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenants_Tenant_Id",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Tenant_Id",
                table: "AspNetUsers",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Tenant_Id",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "AspNetUsers",
                newName: "Tenant_Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Tenant_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenants_Tenant_Id",
                table: "AspNetUsers",
                column: "Tenant_Id",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
