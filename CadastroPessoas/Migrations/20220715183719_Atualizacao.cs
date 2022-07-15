using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProdutos.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_DefSituacaoProduto_DefSituacaoProdutoSituacaoProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_DefUnidadeComercial_DefUnidadeComercialUnidadeComercialID",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "DefUnidadeComercialUnidadeComercialID",
                table: "Produtos",
                newName: "DefUnidadeComercialId");

            migrationBuilder.RenameColumn(
                name: "DefSituacaoProdutoSituacaoProdutoId",
                table: "Produtos",
                newName: "DefSituacaoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_DefUnidadeComercialUnidadeComercialID",
                table: "Produtos",
                newName: "IX_Produtos_DefUnidadeComercialId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_DefSituacaoProdutoSituacaoProdutoId",
                table: "Produtos",
                newName: "IX_Produtos_DefSituacaoProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_DefSituacaoProduto_DefSituacaoProdutoId",
                table: "Produtos",
                column: "DefSituacaoProdutoId",
                principalTable: "DefSituacaoProduto",
                principalColumn: "SituacaoProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_DefUnidadeComercial_DefUnidadeComercialId",
                table: "Produtos",
                column: "DefUnidadeComercialId",
                principalTable: "DefUnidadeComercial",
                principalColumn: "UnidadeComercialID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_DefSituacaoProduto_DefSituacaoProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_DefUnidadeComercial_DefUnidadeComercialId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "DefUnidadeComercialId",
                table: "Produtos",
                newName: "DefUnidadeComercialUnidadeComercialID");

            migrationBuilder.RenameColumn(
                name: "DefSituacaoProdutoId",
                table: "Produtos",
                newName: "DefSituacaoProdutoSituacaoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_DefUnidadeComercialId",
                table: "Produtos",
                newName: "IX_Produtos_DefUnidadeComercialUnidadeComercialID");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_DefSituacaoProdutoId",
                table: "Produtos",
                newName: "IX_Produtos_DefSituacaoProdutoSituacaoProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_DefSituacaoProduto_DefSituacaoProdutoSituacaoProdutoId",
                table: "Produtos",
                column: "DefSituacaoProdutoSituacaoProdutoId",
                principalTable: "DefSituacaoProduto",
                principalColumn: "SituacaoProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_DefUnidadeComercial_DefUnidadeComercialUnidadeComercialID",
                table: "Produtos",
                column: "DefUnidadeComercialUnidadeComercialID",
                principalTable: "DefUnidadeComercial",
                principalColumn: "UnidadeComercialID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
