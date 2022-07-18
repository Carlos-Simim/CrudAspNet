using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProdutos.Migrations
{
    public partial class AtualizacaoEmbalagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEmbalagens_DefSituacaoProdutoEmbalagem_DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                table: "ProdutoEmbalagens");

            migrationBuilder.RenameColumn(
                name: "DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                table: "ProdutoEmbalagens",
                newName: "DefSituacaoProdutoEmbalagemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoEmbalagens_DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                table: "ProdutoEmbalagens",
                newName: "IX_ProdutoEmbalagens_DefSituacaoProdutoEmbalagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEmbalagens_DefSituacaoProdutoEmbalagem_DefSituacaoProdutoEmbalagemId",
                table: "ProdutoEmbalagens",
                column: "DefSituacaoProdutoEmbalagemId",
                principalTable: "DefSituacaoProdutoEmbalagem",
                principalColumn: "SituacaoProdutoEmbalagemID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEmbalagens_DefSituacaoProdutoEmbalagem_DefSituacaoProdutoEmbalagemId",
                table: "ProdutoEmbalagens");

            migrationBuilder.RenameColumn(
                name: "DefSituacaoProdutoEmbalagemId",
                table: "ProdutoEmbalagens",
                newName: "DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoEmbalagens_DefSituacaoProdutoEmbalagemId",
                table: "ProdutoEmbalagens",
                newName: "IX_ProdutoEmbalagens_DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEmbalagens_DefSituacaoProdutoEmbalagem_DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                table: "ProdutoEmbalagens",
                column: "DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                principalTable: "DefSituacaoProdutoEmbalagem",
                principalColumn: "SituacaoProdutoEmbalagemID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}