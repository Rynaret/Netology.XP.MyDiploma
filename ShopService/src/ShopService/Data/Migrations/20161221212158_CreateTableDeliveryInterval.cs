using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopService.Data.Migrations
{
    public partial class CreateTableDeliveryInterval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryIntervals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CronString = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryIntervals", x => x.Id);
                });

            migrationBuilder.AddColumn<long>(
                name: "DeliveryIntervalId",
                table: "Subscriptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_DeliveryIntervalId",
                table: "Subscriptions",
                column: "DeliveryIntervalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_DeliveryIntervals_DeliveryIntervalId",
                table: "Subscriptions",
                column: "DeliveryIntervalId",
                principalTable: "DeliveryIntervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_DeliveryIntervals_DeliveryIntervalId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_DeliveryIntervalId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "DeliveryIntervalId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "DeliveryIntervals");
        }
    }
}
