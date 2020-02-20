﻿using System;
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
                    CartId = table.Column<long>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    TotalDeliveryCost = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
                    SalesChannelData = table.Column<string>(maxLength: 500, nullable: true),
                    LogisticsData = table.Column<string>(maxLength: 500, nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtpTransaction", x => x.AtpTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceConfiguration",
                columns: table => new
                {
                    serviceConfigKey = table.Column<string>(maxLength: 50, nullable: false),
                    serviceConfigValue = table.Column<string>(maxLength: 100, nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atpinfrastructure", x => x.serviceConfigKey);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatus",
                columns: table => new
                {
                    ServiceStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    StatusDescription = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatus", x => x.ServiceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AtpItem",
                columns: table => new
                {
                    ATPItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtpTransactionId = table.Column<long>(nullable: false),
                    LineId = table.Column<int>(nullable: false),
                    InternalItemId = table.Column<long>(nullable: false),
                    ExternalProductId = table.Column<long>(nullable: true),
                    InternalProductId = table.Column<long>(nullable: true),
                    shippingmethod = table.Column<string>(maxLength: 50, nullable: true),
                    QuantityRequested = table.Column<int>(nullable: true),
                    NonMerchFlag = table.Column<bool>(nullable: true),
                    SalesChannelData = table.Column<string>(maxLength: 500, nullable: true),
                    LogisticsData = table.Column<string>(maxLength: 500, nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    Context = table.Column<string>(maxLength: 50, nullable: true),
                    NoteReferenceId = table.Column<string>(maxLength: 20, nullable: true),
                    Note = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    ItemDeliveryCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    DeliveryTimeWindow = table.Column<string>(maxLength: 20, nullable: true),
                    ServiceStatusId = table.Column<int>(nullable: true),
                    DeliveryDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    PickDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShippingDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    DcDeliveryDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeadTimeInDays = table.Column<int>(nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true)
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
                        principalColumn: "ServiceStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemReservation",
                columns: table => new
                {
                    ItemReservationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATPItemId = table.Column<long>(nullable: false),
                    ShippingLocaionExternalId = table.Column<string>(maxLength: 50, nullable: true),
                    ShippingLocaionInternalId = table.Column<int>(nullable: true),
                    PickupLocaionExternalId = table.Column<string>(maxLength: 50, nullable: true),
                    PickupLocaionInternalId = table.Column<int>(nullable: true),
                    QuantityReserved = table.Column<bool>(nullable: true),
                    ServiceStatusId = table.Column<int>(nullable: true),
                    CreateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDatetimeUtc = table.Column<DateTime>(type: "datetime", nullable: true)
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
                        principalColumn: "ServiceStatusId",
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
                column: "Status",
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
