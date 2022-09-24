using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, defaultValueSql: "('')"),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValueSql: "('')"),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_Attributes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Attributes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, defaultValueSql: "('')"),
                    UnitStock = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0.0))"),
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    Classification = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    BaseUnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category",
                        column: x => x.Category_id,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_AttributeDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AddedUnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_AttributeDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_AttributeDetail_Attributes",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_AttributeDetail_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelatedProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseProductId = table.Column<int>(type: "int", nullable: false),
                    RelatedProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_RelatedGoods_Goods_BaseGood",
                        column: x => x.BaseProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelatedGoods_Goods_Related",
                        column: x => x.RelatedProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_ParentId",
                table: "Attributes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AttributeDetail_AttributeId",
                table: "Product_AttributeDetail",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AttributeDetail_ProductId",
                table: "Product_AttributeDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_id",
                table: "Products",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProducts_BaseProductId",
                table: "RelatedProducts",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProducts_RelatedProductId",
                table: "RelatedProducts",
                column: "RelatedProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_AttributeDetail");

            migrationBuilder.DropTable(
                name: "RelatedProducts");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
