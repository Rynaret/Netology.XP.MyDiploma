using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopService.Data.Migrations
{
    public partial class DeliveryIntervalTemplateRefactorFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CronFormatDatesCountInMonth",
                table: "DeliveryIntervalTemplates");

            migrationBuilder.AddColumn<int>(
                name: "DatesCountInMonth",
                table: "DeliveryIntervalTemplates",
                maxLength: 31,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DeliveryIntervalTemplates",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatesCountInMonth",
                table: "DeliveryIntervalTemplates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DeliveryIntervalTemplates");

            migrationBuilder.AddColumn<string>(
                name: "CronFormatDatesCountInMonth",
                table: "DeliveryIntervalTemplates",
                maxLength: 100,
                nullable: true);
        }
    }
}
