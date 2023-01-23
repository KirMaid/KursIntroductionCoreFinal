using Microsoft.EntityFrameworkCore.Migrations;

namespace KursIntroductionCore.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FlightId",
                table: "Transactions",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Flights_FlightId",
                table: "Transactions",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Flights_FlightId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FlightId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Transactions");
        }
    }
}
