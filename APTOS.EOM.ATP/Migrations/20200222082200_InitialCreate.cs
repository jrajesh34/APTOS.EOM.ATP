using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APTOS.EOM.ATPService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtpTransaction",
                columns: table => new
                {
                    AtpTransactionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cartexternalid = table.Column<long>(nullable: true),
                    orderinternalid = table.Column<int>(nullable: true),
                    totaldeliverycost = table.Column<decimal>(type: "numeric(19, 4)", nullable: true),
                    SalesChannelData = table.Column<string>(type: "text", nullable: true),
                    LogisticsData = table.Column<string>(type: "text", nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtpTransaction", x => x.AtpTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceConfiguration",
                columns: table => new
                {
                    SettingKey = table.Column<string>(maxLength: 50, nullable: false),
                    SettingValue = table.Column<string>(maxLength: 100, nullable: false),
                    SettingComments = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atpinfrastructure", x => x.SettingKey);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_pkey", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AtpItem",
                columns: table => new
                {
                    ATPItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtpTransactionId = table.Column<long>(nullable: false),
                    LineId = table.Column<int>(nullable: false),
                    iteminternalid = table.Column<long>(nullable: false),
                    productexternalid = table.Column<long>(nullable: true),
                    productinternalid = table.Column<long>(nullable: true),
                    shippingmethod = table.Column<string>(maxLength: 50, nullable: true),
                    QuantityRequested = table.Column<int>(nullable: true),
                    isnonmerchflag = table.Column<bool>(nullable: true),
                    SalesChannelData = table.Column<string>(maxLength: 500, nullable: true),
                    LogisticsData = table.Column<string>(maxLength: 500, nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtpItem", x => x.ATPItemId);
                    table.ForeignKey(
                        name: "FK_ATPItem_AtpTransaction",
                        column: x => x.AtpTransactionId,
                        principalTable: "AtpTransaction",
                        principalColumn: "AtpTransactionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtpTransactionNotes",
                columns: table => new
                {
                    AtpTransactionNotesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtpTransactionId = table.Column<long>(nullable: false),
                    atptransContext = table.Column<string>(maxLength: 50, nullable: true),
                    NoteReferenceId = table.Column<long>(nullable: true),
                    atptransNote = table.Column<string>(type: "text", nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtpTransactionNotes", x => x.AtpTransactionNotesId);
                    table.ForeignKey(
                        name: "FK_AtpTransactionNotes_AtpTransaction",
                        column: x => x.AtpTransactionId,
                        principalTable: "AtpTransaction",
                        principalColumn: "AtpTransactionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDelivery",
                columns: table => new
                {
                    ItemDeliveryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATPItemId = table.Column<long>(nullable: false),
                    Carrier = table.Column<string>(maxLength: 50, nullable: true),
                    ServiceLevel = table.Column<string>(maxLength: 50, nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    ItemDeliveryCost = table.Column<decimal>(type: "decimal(19, 4)", nullable: true),
                    DeliveryTimeWindow = table.Column<string>(maxLength: 20, nullable: true),
                    ServiceStatusId = table.Column<int>(nullable: true),
                    DeliveryDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    PickDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShippingDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    DcDeliveryDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeadTimeInDays = table.Column<int>(nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDelivery", x => x.ItemDeliveryId);
                    table.ForeignKey(
                        name: "FK_ItemDelivery_ATPItem",
                        column: x => x.ATPItemId,
                        principalTable: "AtpItem",
                        principalColumn: "ATPItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDelivery_ATPStatus",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemReservation",
                columns: table => new
                {
                    ItemReservationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATPItemId = table.Column<long>(nullable: false),
                    ShippingLocationExternalId = table.Column<string>(maxLength: 50, nullable: false),
                    ShippingLocationInternalId = table.Column<int>(nullable: false),
                    PickupLocationExternalId = table.Column<string>(maxLength: 50, nullable: false),
                    PickupLocationInternalId = table.Column<int>(nullable: false),
                    IsQuantityReservedFlag = table.Column<bool>(nullable: false),
                    ServiceStatusId = table.Column<int>(nullable: false),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReservation", x => x.ItemReservationId);
                    table.ForeignKey(
                        name: "FK_ItemReservation_ATPItem",
                        column: x => x.ATPItemId,
                        principalTable: "AtpItem",
                        principalColumn: "ATPItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemReservation_ATPStatus",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtpItem_AtpTransactionId",
                table: "AtpItem",
                column: "AtpTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_AtpTransactionNotes_AtpTransactionId",
                table: "AtpTransactionNotes",
                column: "AtpTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDelivery_ATPItemId",
                table: "ItemDelivery",
                column: "ATPItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDelivery_ServiceStatusId",
                table: "ItemDelivery",
                column: "ServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReservation_ATPItemId",
                table: "ItemReservation",
                column: "ATPItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReservation_ServiceStatusId",
                table: "ItemReservation",
                column: "ServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "status_atpstatusname_key",
                table: "ServiceStatus",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtpTransactionNotes");

            migrationBuilder.DropTable(
                name: "ItemDelivery");

            migrationBuilder.DropTable(
                name: "ItemReservation");

            migrationBuilder.DropTable(
                name: "ServiceConfiguration");

            migrationBuilder.DropTable(
                name: "AtpItem");

            migrationBuilder.DropTable(
                name: "ServiceStatus");

            migrationBuilder.DropTable(
                name: "AtpTransaction");
        }
    }
}
