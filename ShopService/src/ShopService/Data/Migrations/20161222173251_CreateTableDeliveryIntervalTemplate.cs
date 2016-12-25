using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopService.Data.Migrations
{
    public partial class CreateTableDeliveryIntervalTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryIntervalTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CronFormatDatesCountInMonth = table.Column<string>(maxLength: 100, nullable: true),
                    CronFormatMonthFrequency = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryIntervalTemplates", x => x.Id);
                });

            migrationBuilder.AddColumn<long>(
                name: "DeliveryIntervalTemplateId",
                table: "DeliveryIntervals",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryIntervals_DeliveryIntervalTemplateId",
                table: "DeliveryIntervals",
                column: "DeliveryIntervalTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryIntervals_DeliveryIntervalTemplates_DeliveryIntervalTemplateId",
                table: "DeliveryIntervals",
                column: "DeliveryIntervalTemplateId",
                principalTable: "DeliveryIntervalTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryIntervals_DeliveryIntervalTemplates_DeliveryIntervalTemplateId",
                table: "DeliveryIntervals");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryIntervals_DeliveryIntervalTemplateId",
                table: "DeliveryIntervals");

            migrationBuilder.DropColumn(
                name: "DeliveryIntervalTemplateId",
                table: "DeliveryIntervals");

            migrationBuilder.DropTable(
                name: "DeliveryIntervalTemplates");
        }
    }
}
