using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentStatusEntities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatusEntities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentEntities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusID = table.Column<int>(nullable: false),
                    PaymentStatusEntitiesID = table.Column<int>(nullable: true),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    CardHolder = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    SecurityCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentEntities", x => x.ID);
                    table.UniqueConstraint("AK_PaymentEntities_StatusID", x => x.StatusID);
                    table.ForeignKey(
                        name: "FK_PaymentEntities_PaymentStatusEntities_PaymentStatusEntitiesID",
                        column: x => x.PaymentStatusEntitiesID,
                        principalTable: "PaymentStatusEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentEntities_PaymentStatusEntitiesID",
                table: "PaymentEntities",
                column: "PaymentStatusEntitiesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentEntities");

            migrationBuilder.DropTable(
                name: "PaymentStatusEntities");
        }
    }
}
