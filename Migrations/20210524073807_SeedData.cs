using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashTransferAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Balances",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "Balances",
                columns: new[] { "Id", "AccountBalance", "AccountNumber" },
                values: new object[] { 1, 5000.9799999999996, 1234567890 });

            migrationBuilder.InsertData(
                table: "Balances",
                columns: new[] { "Id", "AccountBalance", "AccountNumber" },
                values: new object[] { 2, 10000.0, 987654321 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Reference", "Amount", "BalanceId" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 5000.9799999999996, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Reference", "Amount", "BalanceId" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 5000.9799999999996, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Reference",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Reference",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<long>(
                name: "AccountNumber",
                table: "Balances",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
