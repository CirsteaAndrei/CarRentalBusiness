using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CarPriceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Cars_CarId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "RentingContracts");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_CarId",
                table: "RentingContracts",
                newName: "IX_RentingContracts_CarId");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cars",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentingContracts",
                table: "RentingContracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentingContracts_Cars_CarId",
                table: "RentingContracts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentingContracts_Cars_CarId",
                table: "RentingContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentingContracts",
                table: "RentingContracts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "RentingContracts",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_RentingContracts_CarId",
                table: "Contracts",
                newName: "IX_Contracts_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Cars_CarId",
                table: "Contracts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
