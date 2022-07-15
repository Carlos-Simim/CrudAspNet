using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProdutos.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefSituacaoProduto",
                columns: table => new
                {
                    SituacaoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSituacao = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefSituacaoProduto", x => x.SituacaoProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "DefSituacaoProdutoEmbalagem",
                columns: table => new
                {
                    SituacaoProdutoEmbalagemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSituacao = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefSituacaoProdutoEmbalagem", x => x.SituacaoProdutoEmbalagemID);
                });

            migrationBuilder.CreateTable(
                name: "DefUnidadeComercial",
                columns: table => new
                {
                    UnidadeComercialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefUnidadeComercial", x => x.UnidadeComercialID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(120)", nullable: false),
                    DefSituacaoProdutoSituacaoProdutoId = table.Column<int>(type: "int", nullable: false),
                    DefUnidadeComercialUnidadeComercialID = table.Column<int>(type: "int", nullable: false),
                    PesoLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_DefSituacaoProduto_DefSituacaoProdutoSituacaoProdutoId",
                        column: x => x.DefSituacaoProdutoSituacaoProdutoId,
                        principalTable: "DefSituacaoProduto",
                        principalColumn: "SituacaoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_DefUnidadeComercial_DefUnidadeComercialUnidadeComercialID",
                        column: x => x.DefUnidadeComercialUnidadeComercialID,
                        principalTable: "DefUnidadeComercial",
                        principalColumn: "UnidadeComercialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEmbalagens",
                columns: table => new
                {
                    ProdutoEmbalagemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    FatorDeConversao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEmbalagens", x => x.ProdutoEmbalagemID);
                    table.ForeignKey(
                        name: "FK_ProdutoEmbalagens_DefSituacaoProdutoEmbalagem_DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                        column: x => x.DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID,
                        principalTable: "DefSituacaoProdutoEmbalagem",
                        principalColumn: "SituacaoProdutoEmbalagemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoEmbalagens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEmbalagens_DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID",
                table: "ProdutoEmbalagens",
                column: "DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEmbalagens_ProdutoId",
                table: "ProdutoEmbalagens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_DefSituacaoProdutoSituacaoProdutoId",
                table: "Produtos",
                column: "DefSituacaoProdutoSituacaoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_DefUnidadeComercialUnidadeComercialID",
                table: "Produtos",
                column: "DefUnidadeComercialUnidadeComercialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoEmbalagens");

            migrationBuilder.DropTable(
                name: "DefSituacaoProdutoEmbalagem");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "DefSituacaoProduto");

            migrationBuilder.DropTable(
                name: "DefUnidadeComercial");
        }
    }
}
