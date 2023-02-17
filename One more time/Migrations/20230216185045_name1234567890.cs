using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_more_time.Migrations
{
    /// <inheritdoc />
    public partial class name1234567890 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Bands_BrandId",
                table: "Laptops");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Bands_BrandId",
                table: "Laptops",
                column: "BrandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Bands_BrandId",
                table: "Laptops");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Laptops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Bands_BrandId",
                table: "Laptops",
                column: "BrandId",
                principalTable: "Bands",
                principalColumn: "Id");
        }
    }
}
