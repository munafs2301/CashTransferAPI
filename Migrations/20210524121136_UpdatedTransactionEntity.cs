using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashTransferAPI.Migrations
{
    public partial class UpdatedTransactionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryAcccount",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Reference",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                column: "BeneficiaryAcccount",
                value: 987654321);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Reference",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                column: "BeneficiaryAcccount",
                value: 1234567890);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryAcccount",
                table: "Transactions");
        }
    }
}
