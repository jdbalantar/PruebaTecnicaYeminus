using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncryptionSoftware.Persistence.Migrations
{
    public partial class Secambialaestructuradelatablaproductosyseleañandeinformacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ListaDePrecios",
                table: "Productos",
                type: "text",
                nullable: false,
                oldClrType: typeof(List<int>),
                oldType: "integer[]");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Codigo", "Descripcion", "Imagen", "Iva", "ListaDePrecios", "ProductoParaLaVenta" },
                values: new object[,]
                {
                    { 1, "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops", "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg", 19, "[]", true },
                    { 2, "Mens Casual Premium Slim Fit T-Shirts", "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg", 19, "[]", true },
                    { 3, "Mens Cotton Jacket", "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg", 19, "[5000]", true },
                    { 4, "Mens Casual Slim Fit", "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg", 19, "[50000]", true },
                    { 5, "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet", "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg", 19, "[50400]", true },
                    { 6, "Solid Gold Petite Micropave", "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg", 19, "[4500]", true },
                    { 7, "White Gold Plated Princess", "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg", 19, "[95000]", true },
                    { 8, "Pierced Owl Rose Gold Plated Stainless Steel Double", "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg", 19, "[36800]", true },
                    { 9, "WD 2TB Elements Portable External Hard Drive - USB 3.0", "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg", 19, "[89000]", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Codigo",
                keyValue: 9);

            migrationBuilder.AlterColumn<List<int>>(
                name: "ListaDePrecios",
                table: "Productos",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
