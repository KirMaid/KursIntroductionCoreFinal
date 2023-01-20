using Microsoft.EntityFrameworkCore.Migrations;

namespace KursIntroductionCore.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "FareId",
               table: "Flights",
               type: "integer",
               nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FareId",
                table: "Flights",
                column: "FareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Fares_FareId",
                table: "Flights",
                column: "FareId",
                principalTable: "Fares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            /*  migrationBuilder.DropForeignKey(
                  name: "FK_Flights_Transactions_TransactionId",
                  table: "Flights");

              migrationBuilder.DropIndex(
                  name: "IX_Flights_TransactionId",
                  table: "Flights");

              migrationBuilder.DropColumn(
                  name: "TransactionId",
                  table: "Flights");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FareId",
                table: "Flights",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FareId",
                table: "Flights",
                column: "FareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Fares_FareId",
                table: "Flights",
                column: "FareId",
                principalTable: "Fares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
