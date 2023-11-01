using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChemistWarehousePizzeria.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Toppings = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzeria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzeria_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzeria_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    PizzaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Price_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PizzeriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "Pizzeria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PizzaMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaMen_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaMenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PizzaMenu_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wyndhamvale" },
                    { 2, "Docklands" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "Name", "Toppings" },
                values: new object[,]
                {
                    { 1, "Veg-SpicyPanner", "Cheese, Panner, Olives" },
                    { 2, "VegManorama", "Cheese, Capsicum, Chilli" },
                    { 3, "Margherita", "Cheese, Spinach, Cherry Tomatoes" },
                    { 4, "Vegetarian", "Cheese, Mushrooms, Capsicum, Onion, Olives" }
                });

            migrationBuilder.InsertData(
                table: "Pizzeria",
                columns: new[] { "Id", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "PizzaHouse Wyndhamvale" },
                    { 2, 2, "PizzaHouse Docklands" }
                });

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "Id", "EffectiveDate", "LocationId", "PizzaId", "Value" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 20m },
                    { 2, null, 1, 2, 18m },
                    { 3, null, 1, 3, 22m },
                    { 4, null, 2, 1, 25m },
                    { 5, null, 2, 4, 17m }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Name", "PizzeriaId" },
                values: new object[,]
                {
                    { 1, "Main Menu", 1 },
                    { 2, "Main Menu", 2 }
                });

            migrationBuilder.InsertData(
                table: "PizzaMenu",
                columns: new[] { "Id", "MenuId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 1 },
                    { 5, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PizzeriaId",
                table: "Menu",
                column: "PizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaMenu_MenuId",
                table: "PizzaMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaMenu_PizzaId",
                table: "PizzaMenu",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzeria_LocationId",
                table: "Pizzeria",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_LocationId",
                table: "Price",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_PizzaId",
                table: "Price",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaMenu");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Pizzeria");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
