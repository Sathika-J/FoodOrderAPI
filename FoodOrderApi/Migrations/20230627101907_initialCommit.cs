using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<int>(name: "Phone Number", type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantID);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantWithMenus",
                columns: table => new
                {
                    RestaurantID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<int>(name: "Phone Number", type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Menus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantWithMenus", x => x.RestaurantID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(name: "Item ID", type: "TEXT", nullable: false),
                    RestaurantID = table.Column<Guid>(name: "Restaurant ID", type: "TEXT", nullable: false),
                    ItemName = table.Column<string>(name: "Item Name", type: "TEXT", nullable: false),
                    ItemPrice = table.Column<double>(name: "Item Price (₹)", type: "REAL", precision: 2, scale: 3, nullable: false),
                    ItemDiscount = table.Column<double>(name: "Item Discount (%)", type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_Restaurant ID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RestaurantID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(name: "Customer Name", type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Menus_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Menus",
                        principalColumn: "Item ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RestaurantWithMenus",
                columns: new[] { "RestaurantID", "Menus", "Address", "Name", "Phone Number", "Type" },
                values: new object[,]
                {
                    { new Guid("0c2b4710-050e-4794-8031-e5fc19ef13b4"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Jupiter", "KB Bhavan", 1234567890, "Fine Dining" },
                    { new Guid("2818b184-94be-4a91-a3b8-a510b00bd6f5"), "Vegetable Club Sandwich,Veg Combo Meal,Orbis Signature Rice\r\n", "Avinashi Road", "Orbis", 1234567890, "Multi Cuisine" },
                    { new Guid("6069ced7-f6cf-4d8d-999e-78566375ad55"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Mars", "Mario Hotel", 1234567890, "Fine Dining" },
                    { new Guid("7a03ca50-719f-48e7-ae0e-e4e299f3112b"), "Chocolate Sizzler,Choco Brownie Bomb,Chocolate Cookies\r\n", "Race Course Road", "Chocolate Room", 1234567890, "Desserts and Beerages" },
                    { new Guid("7e83a461-5a28-4b11-83a5-31458449b7ac"), "Idly(2),Pongal,Roast\r\n", "RS Puram", "Annapoorna", 1234567890, "Casual Dining" },
                    { new Guid("a082a822-c7f0-4ea0-837d-957a5b154908"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Kalpakam", "Arya Bhavan", 1234567890, "Fine Dining" },
                    { new Guid("baad586a-accf-4433-98f0-2f861e683354"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Ramanathpuram", "Kove", 1234567890, "Fine Dining" },
                    { new Guid("d487c6ec-2a8b-44a1-ba0e-f4ff24a9e7ce"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Perambur", "Adyar Anadha Bhavan", 1234567890, "Fine Dining" },
                    { new Guid("ee05c50f-d96e-4fd8-b84e-708c772dc026"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Pluto", "SMS Hotel", 1234567890, "Fine Dining" },
                    { new Guid("f40029f8-9c8f-4abf-8db5-ffa00a13d1cd"), "Thai Broccoli Salad,Curd Rice Aracini,Chettinad Cutlet\r\n", "Peelamedu", "Anadha Bhavan", 1234567890, "Fine Dining" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantID", "Address", "Name", "Phone Number", "Type" },
                values: new object[,]
                {
                    { new Guid("0c2b4710-050e-4794-8031-e5fc19ef13b4"), "Jupiter", "KB Bhavan", 1234567890, "Fine Dining" },
                    { new Guid("2818b184-94be-4a91-a3b8-a510b00bd6f5"), "Avinashi Road", "Orbis", 1234567890, "Multi Cuisine" },
                    { new Guid("6069ced7-f6cf-4d8d-999e-78566375ad55"), "Mars", "Mario Hotel", 1234567890, "Fine Dining" },
                    { new Guid("7a03ca50-719f-48e7-ae0e-e4e299f3112b"), "Race Course Road", "Chocolate Room", 1234567890, "Desserts and Beerages" },
                    { new Guid("7e83a461-5a28-4b11-83a5-31458449b7ac"), "RS Puram", "Annapoorna", 1234567890, "Casual Dining" },
                    { new Guid("a082a822-c7f0-4ea0-837d-957a5b154908"), "Kalpakam", "Arya Bhavan", 1234567890, "Fine Dining" },
                    { new Guid("baad586a-accf-4433-98f0-2f861e683354"), "Ramanathpuram", "Kove", 1234567890, "Fine Dining" },
                    { new Guid("d487c6ec-2a8b-44a1-ba0e-f4ff24a9e7ce"), "Perambur", "Adyar Anadha Bhavan", 1234567890, "Fine Dining" },
                    { new Guid("ee05c50f-d96e-4fd8-b84e-708c772dc026"), "Pluto", "SMS Hotel", 1234567890, "Fine Dining" },
                    { new Guid("f40029f8-9c8f-4abf-8db5-ffa00a13d1cd"), "Peelamedu", "Anadha Bhavan", 1234567890, "Fine Dining" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Item ID", "Item Name", "Item Discount (%)", "Item Price (₹)", "Restaurant ID" },
                values: new object[,]
                {
                    { new Guid("019ec633-f286-4955-b473-d510daf80960"), "Chettinad Cutlet", 30.0, 255.0, new Guid("6069ced7-f6cf-4d8d-999e-78566375ad55") },
                    { new Guid("0bd3debf-0ec8-4cb4-9497-e76da79eb9c8"), "Curd Rice Aracini", 20.0, 205.0, new Guid("ee05c50f-d96e-4fd8-b84e-708c772dc026") },
                    { new Guid("0c976706-286a-4f66-a65b-12461d8847fb"), "Thai Broccoli Salad", 10.0, 200.0, new Guid("a082a822-c7f0-4ea0-837d-957a5b154908") },
                    { new Guid("1ff36c1a-3e10-4651-88e4-7fc4736bf4d8"), "Chocolate Sizzler", 10.0, 299.0, new Guid("7a03ca50-719f-48e7-ae0e-e4e299f3112b") },
                    { new Guid("2318c8a7-f867-415d-8427-df4bbe527796"), "Thai Broccoli Salad", 10.0, 200.0, new Guid("ee05c50f-d96e-4fd8-b84e-708c772dc026") },
                    { new Guid("26986da6-4610-472e-b14a-30a713bdd30e"), "Thai Broccoli Salad", 10.0, 205.0, new Guid("f40029f8-9c8f-4abf-8db5-ffa00a13d1cd") },
                    { new Guid("289f9767-e25f-407d-ae50-72c3debe8ced"), "Chettinad Cutlet", 30.0, 255.0, new Guid("d487c6ec-2a8b-44a1-ba0e-f4ff24a9e7ce") },
                    { new Guid("316dc710-146c-430b-9b0f-e9aa51b1e8e9"), "Choco Brownie Bomb", 20.0, 249.0, new Guid("7a03ca50-719f-48e7-ae0e-e4e299f3112b") },
                    { new Guid("3a011230-db41-4407-9218-347f51391818"), "Chocolate Cookies", 30.0, 199.0, new Guid("7a03ca50-719f-48e7-ae0e-e4e299f3112b") },
                    { new Guid("5849b06f-9731-4e31-a908-6e7e9dafdd5a"), "Orbis Signature Rice", 30.0, 250.0, new Guid("2818b184-94be-4a91-a3b8-a510b00bd6f5") },
                    { new Guid("6c9ba650-6204-4ba0-9602-4413932e36b1"), "Curd Rice Aracini", 20.0, 205.0, new Guid("6069ced7-f6cf-4d8d-999e-78566375ad55") },
                    { new Guid("6fa050ad-d0c1-41f0-a131-610c3e78e03d"), "Chettinad Cutlet", 30.0, 255.0, new Guid("0c2b4710-050e-4794-8031-e5fc19ef13b4") },
                    { new Guid("768b93dd-e9d4-4a64-941c-cf4a902b75a6"), "Chettinad Cutlet", 30.0, 255.0, new Guid("a082a822-c7f0-4ea0-837d-957a5b154908") },
                    { new Guid("780717ad-8473-4c23-b9b0-a256fd80f13f"), "Pongal", 20.0, 48.0, new Guid("7e83a461-5a28-4b11-83a5-31458449b7ac") },
                    { new Guid("8de20733-568b-430d-b642-a3a5254b6418"), "Curd Rice Aracini", 20.0, 205.0, new Guid("0c2b4710-050e-4794-8031-e5fc19ef13b4") },
                    { new Guid("983fc832-5371-4bdc-af27-bd14f5998f44"), "Curd Rice Aracini", 20.0, 200.0, new Guid("baad586a-accf-4433-98f0-2f861e683354") },
                    { new Guid("999c9f43-5153-4e08-b471-1015bf08498e"), "Curd Rice Aracini", 20.0, 205.0, new Guid("a082a822-c7f0-4ea0-837d-957a5b154908") },
                    { new Guid("a91be131-8704-45ae-9ba7-60e70c58abb4"), "Veg Combo Meal", 20.0, 439.0, new Guid("2818b184-94be-4a91-a3b8-a510b00bd6f5") },
                    { new Guid("ae527a12-be03-4ac1-8206-7345a1a90bf6"), "Chettinad Cutlet", 30.0, 255.0, new Guid("baad586a-accf-4433-98f0-2f861e683354") },
                    { new Guid("b6b56f12-0ac4-401c-82c6-9a5103870ed8"), "Thai Broccoli Salad", 10.0, 200.0, new Guid("d487c6ec-2a8b-44a1-ba0e-f4ff24a9e7ce") },
                    { new Guid("be5a857b-1336-4d13-a1d8-b0c9683689ca"), "Idly(2)", 10.0, 33.0, new Guid("7e83a461-5a28-4b11-83a5-31458449b7ac") },
                    { new Guid("c8e03d8c-3438-4583-b12e-1ba54c3670d6"), "Vegetable Club Sandwich", 10.0, 150.0, new Guid("2818b184-94be-4a91-a3b8-a510b00bd6f5") },
                    { new Guid("cfa81f1b-9db5-43a4-962d-506e68615495"), "Thai Broccoli Salad", 10.0, 200.0, new Guid("0c2b4710-050e-4794-8031-e5fc19ef13b4") },
                    { new Guid("d636db98-a948-45ab-956b-9078a9252a42"), "Chettinad Cutlet", 30.0, 255.0, new Guid("f40029f8-9c8f-4abf-8db5-ffa00a13d1cd") },
                    { new Guid("e0194510-6ad1-4ac2-bf31-e572caa09ba1"), "Thai Broccoli Salad", 10.0, 205.0, new Guid("baad586a-accf-4433-98f0-2f861e683354") },
                    { new Guid("e1764da4-941d-463a-8531-43b701306780"), "Roast", 30.0, 75.0, new Guid("7e83a461-5a28-4b11-83a5-31458449b7ac") },
                    { new Guid("ea6460df-d676-426c-8699-ae19230d743e"), "Thai Broccoli Salad", 10.0, 200.0, new Guid("6069ced7-f6cf-4d8d-999e-78566375ad55") },
                    { new Guid("f1b97db8-9b54-4616-8d49-b36e4cd08f5f"), "Chettinad Cutlet", 30.0, 255.0, new Guid("ee05c50f-d96e-4fd8-b84e-708c772dc026") },
                    { new Guid("f2612c12-b189-4d23-9532-e7c07a1eebe3"), "Curd Rice Aracini", 20.0, 275.0, new Guid("f40029f8-9c8f-4abf-8db5-ffa00a13d1cd") },
                    { new Guid("f613a27f-93c2-4028-9deb-ddc4b8b45e3a"), "Curd Rice Aracini", 20.0, 265.0, new Guid("d487c6ec-2a8b-44a1-ba0e-f4ff24a9e7ce") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Restaurant ID",
                table: "Menus",
                column: "Restaurant ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantID",
                table: "Orders",
                column: "RestaurantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RestaurantWithMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
