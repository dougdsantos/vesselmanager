using Microsoft.EntityFrameworkCore.Migrations;

namespace VesselManager.Infra.Migrations
{
    public partial class UpdatingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipaments_Vessels_VesselId",
                table: "Equipaments");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_code",
                table: "Vessels");

            migrationBuilder.RenameColumn(
                name: "VesselId",
                table: "Equipaments",
                newName: "vesselId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipaments_VesselId",
                table: "Equipaments",
                newName: "IX_Equipaments_vesselId");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Vessels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_code",
                table: "Vessels",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipaments_Vessels_vesselId",
                table: "Equipaments",
                column: "vesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipaments_Vessels_vesselId",
                table: "Equipaments");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_code",
                table: "Vessels");

            migrationBuilder.RenameColumn(
                name: "vesselId",
                table: "Equipaments",
                newName: "VesselId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipaments_vesselId",
                table: "Equipaments",
                newName: "IX_Equipaments_VesselId");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Vessels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_code",
                table: "Vessels",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipaments_Vessels_VesselId",
                table: "Equipaments",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
