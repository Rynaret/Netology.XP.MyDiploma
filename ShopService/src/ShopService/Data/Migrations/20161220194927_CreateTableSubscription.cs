using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopService.Data.Migrations
{
    public partial class CreateTableSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.AddColumn<long>(
                name: "SubscriptionId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubscriptionId",
                table: "Products",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subscriptions_SubscriptionId",
                table: "Products",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subscriptions_SubscriptionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubscriptionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
