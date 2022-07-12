using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProdutos.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ProdutoEmbalagens_ProdutoEmbalagemID",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ProdutoEmbalagemID",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoEmbalagemID",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoID",
                table: "ProdutoEmbalagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEmbalagens_ProdutoID",
                table: "ProdutoEmbalagens",
                column: "ProdutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEmbalagens_Produtos_ProdutoID",
                table: "ProdutoEmbalagens",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEmbalagens_Produtos_ProdutoID",
                table: "ProdutoEmbalagens");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoEmbalagens_ProdutoID",
                table: "ProdutoEmbalagens");

            migrationBuilder.DropColumn(
                name: "ProdutoID",
                table: "ProdutoEmbalagens");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoEmbalagemID",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoEmbalagemID",
                table: "Produtos",
                column: "ProdutoEmbalagemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ProdutoEmbalagens_ProdutoEmbalagemID",
                table: "Produtos",
                column: "ProdutoEmbalagemID",
                principalTable: "ProdutoEmbalagens",
                principalColumn: "ProdutoEmbalagemID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
