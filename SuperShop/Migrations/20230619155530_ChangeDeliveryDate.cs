using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperShop.Migrations
{
    public partial class ChangeDeliveryDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetailTemp_AspNetUsers_UserId",
                table: "orderDetailTemp");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetailTemp_Products_ProductId",
                table: "orderDetailTemp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderDetailTemp",
                table: "orderDetailTemp");

            migrationBuilder.RenameTable(
                name: "orderDetailTemp",
                newName: "OrderDetailTemp");

            migrationBuilder.RenameIndex(
                name: "IX_orderDetailTemp_UserId",
                table: "OrderDetailTemp",
                newName: "IX_OrderDetailTemp_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_orderDetailTemp_ProductId",
                table: "OrderDetailTemp",
                newName: "IX_OrderDetailTemp_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailTemp",
                table: "OrderDetailTemp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailTemp_AspNetUsers_UserId",
                table: "OrderDetailTemp",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailTemp_Products_ProductId",
                table: "OrderDetailTemp",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailTemp_AspNetUsers_UserId",
                table: "OrderDetailTemp");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailTemp_Products_ProductId",
                table: "OrderDetailTemp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailTemp",
                table: "OrderDetailTemp");

            migrationBuilder.RenameTable(
                name: "OrderDetailTemp",
                newName: "orderDetailTemp");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailTemp_UserId",
                table: "orderDetailTemp",
                newName: "IX_orderDetailTemp_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailTemp_ProductId",
                table: "orderDetailTemp",
                newName: "IX_orderDetailTemp_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderDetailTemp",
                table: "orderDetailTemp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetailTemp_AspNetUsers_UserId",
                table: "orderDetailTemp",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetailTemp_Products_ProductId",
                table: "orderDetailTemp",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}