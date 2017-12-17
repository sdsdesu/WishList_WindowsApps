using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WislistDataCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WishListModel",
                columns: table => new
                {
                    ListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListModel", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_WishListModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoryid = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WebLink = table.Column<string>(nullable: true),
                    WishListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ItemModel_CategoryModel_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "CategoryModel",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemModel_WishListModel_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishListModel",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_Categoryid",
                table: "ItemModel",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_WishListId",
                table: "ItemModel",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListModel_UserId",
                table: "WishListModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropTable(
                name: "CategoryModel");

            migrationBuilder.DropTable(
                name: "WishListModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
