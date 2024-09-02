using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotoFleet.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class Create_Database : Migration
{
    private static readonly string[] columns = new[] { "Id", "FinePercentage", "NumberDays", "Price" };

    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "public");

        migrationBuilder.CreateTable(
            name: "DeliveryPersons",
            schema: "public",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                CnpjCpf = table.Column<string>(type: "text", nullable: false),
                DateBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Cnh = table.Column<string>(type: "text", nullable: false),
                CnhType = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_DeliveryPersons", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Motorcycles",
            schema: "public",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Year = table.Column<int>(type: "integer", nullable: false),
                Model = table.Column<string>(type: "text", nullable: false),
                Plate = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Motorcycles", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Plans",
            schema: "public",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                NumberDays = table.Column<int>(type: "integer", nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false),
                FinePercentage = table.Column<decimal>(type: "numeric", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Plans", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Rentals",
            schema: "public",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                MotorcycleId = table.Column<Guid>(type: "uuid", nullable: false),
                DeliveryPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ExpectedEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                IsReturned = table.Column<bool>(type: "boolean", nullable: false),
                CalculatedPrice = table.Column<decimal>(type: "numeric", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rentals", x => x.Id);
                table.ForeignKey(
                    name: "FK_Rentals_DeliveryPersons_DeliveryPersonId",
                    column: x => x.DeliveryPersonId,
                    principalSchema: "public",
                    principalTable: "DeliveryPersons",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Rentals_Motorcycles_MotorcycleId",
                    column: x => x.MotorcycleId,
                    principalSchema: "public",
                    principalTable: "Motorcycles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Rentals_Plans_PlanId",
                    column: x => x.PlanId,
                    principalSchema: "public",
                    principalTable: "Plans",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            schema: "public",
            table: "Plans",
            columns: columns,
            values: new object[,]
            {
                { new Guid("0568d77d-285b-43a5-8a70-6e0223d5d05d"), 40m, 45, 20m },
                { new Guid("14170a49-3a12-4eba-b24c-6f36f34e9c76"), 40m, 30, 22m },
                { new Guid("57193539-b9f1-49cc-a06d-28a1d7842041"), 40m, 15, 28m },
                { new Guid("5b8f8d85-5f53-4171-9781-b6aac9acd775"), 20m, 7, 30m },
                { new Guid("ff361b97-769f-42fc-badf-0ead1e8df8e4"), 40m, 50, 18m }
            });

        migrationBuilder.CreateIndex(
            name: "IX_DeliveryPersons_Cnh",
            schema: "public",
            table: "DeliveryPersons",
            column: "Cnh",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_DeliveryPersons_CnpjCpf",
            schema: "public",
            table: "DeliveryPersons",
            column: "CnpjCpf",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Motorcycles_Plate",
            schema: "public",
            table: "Motorcycles",
            column: "Plate",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Rentals_DeliveryPersonId",
            schema: "public",
            table: "Rentals",
            column: "DeliveryPersonId");

        migrationBuilder.CreateIndex(
            name: "IX_Rentals_MotorcycleId",
            schema: "public",
            table: "Rentals",
            column: "MotorcycleId");

        migrationBuilder.CreateIndex(
            name: "IX_Rentals_PlanId",
            schema: "public",
            table: "Rentals",
            column: "PlanId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Rentals",
            schema: "public");

        migrationBuilder.DropTable(
            name: "DeliveryPersons",
            schema: "public");

        migrationBuilder.DropTable(
            name: "Motorcycles",
            schema: "public");

        migrationBuilder.DropTable(
            name: "Plans",
            schema: "public");
    }
}
