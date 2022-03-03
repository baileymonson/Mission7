using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        BookID = table.Column<long>(nullable: false),
            //        Title = table.Column<string>(nullable: false),
            //        Author = table.Column<string>(nullable: false),
            //        Publisher = table.Column<string>(nullable: false),
            //        ISBN = table.Column<string>(nullable: false),
            //        Classification = table.Column<string>(nullable: false),
            //        Category = table.Column<string>(nullable: false),
            //        PageCount = table.Column<long>(nullable: false),
            //        Price = table.Column<double>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.BookID);
            //    });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Anonymous = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLineItem",
                columns: table => new
                {
                    LineId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DonationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLineItem", x => x.LineId);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_BookId",
                table: "BasketLineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_DonationId",
                table: "BasketLineItem",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookID",
                table: "Books",
                column: "BookID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketLineItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
