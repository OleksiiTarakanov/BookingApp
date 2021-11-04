using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Migrations
{
    public partial class ChangedTablePlaceClassAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TablePlaceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TablePlaceId",
                table: "Bookings",
                column: "TablePlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_TablePlaceId",
                table: "Bookings",
                column: "TablePlaceId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_TablePlaceId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TablePlaceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TablePlaceId",
                table: "Bookings");
        }
    }
}
