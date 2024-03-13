using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Tesla.Migrations
{
    /// <inheritdoc />
    public partial class Iden2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OurCars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OurCars_UserId",
                table: "OurCars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OurCars_AspNetUsers_UserId",
                table: "OurCars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OurCars_AspNetUsers_UserId",
                table: "OurCars");

            migrationBuilder.DropIndex(
                name: "IX_OurCars_UserId",
                table: "OurCars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OurCars");
        }
    }
}
