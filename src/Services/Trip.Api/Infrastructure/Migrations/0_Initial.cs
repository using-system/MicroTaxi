namespace Trip.Api.Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Trip");

            //migrationBuilder.CreateTable(
            //   name: "Trips",
            //   schema: "Trip",
            //   columns: table => new
            //   {
            //       Id = table.Column<int>(nullable: false),
            //       AddressId = table.Column<int>(nullable: true),
            //       BuyerId = table.Column<int>(nullable: false),
            //       OrderDate = table.Column<DateTime>(nullable: false),
            //       OrderStatusId = table.Column<int>(nullable: false),
            //       PaymentMethodId = table.Column<int>(nullable: false)
            //   },
            //   constraints: table =>
            //   {
            //       table.PrimaryKey("PK_Trips", x => x.Id);
            //       table.ForeignKey(
            //           name: "FK_orders_address_AddressId",
            //           column: x => x.AddressId,
            //           principalSchema: "ordering",
            //           principalTable: "address",
            //           principalColumn: "Id",
            //           onDelete: ReferentialAction.Restrict);
            //       table.ForeignKey(
            //           name: "FK_orders_buyers_BuyerId",
            //           column: x => x.BuyerId,
            //           principalSchema: "ordering",
            //           principalTable: "buyers",
            //           principalColumn: "Id",
            //           onDelete: ReferentialAction.Cascade);
            //       table.ForeignKey(
            //           name: "FK_orders_orderstatus_OrderStatusId",
            //           column: x => x.OrderStatusId,
            //           principalSchema: "ordering",
            //           principalTable: "orderstatus",
            //           principalColumn: "Id",
            //           onDelete: ReferentialAction.Cascade);
            //       table.ForeignKey(
            //           name: "FK_orders_paymentmethods_PaymentMethodId",
            //           column: x => x.PaymentMethodId,
            //           principalSchema: "ordering",
            //           principalTable: "paymentmethods",
            //           principalColumn: "Id",
            //           onDelete: ReferentialAction.Restrict);
            //   });
        }
    }
}
