using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Shared.Migrations
{
    public partial class CorreccionMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Id_Proveedor",
                table: "Proveedores");

            migrationBuilder.AlterColumn<decimal>(
                name: "Telefono",
                table: "Proveedores",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Proveedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");

            migrationBuilder.CreateIndex(
                name: "UQ_Id_Proveedor",
                table: "Proveedores",
                column: "Id",
                unique: true);
        }
    }
}
