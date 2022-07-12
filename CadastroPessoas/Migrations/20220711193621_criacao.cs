using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProdutos.Migrations
{
    public partial class criacao : Migration
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
                name: "ProdutoEmbalagens",
                columns: table => new
                {
                    ProdutoEmbalagemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoProdutoEmbalagemID = table.Column<int>(type: "int", nullable: false),
                    FatorDeConversao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEmbalagens", x => x.ProdutoEmbalagemID);
                    table.ForeignKey(
                        name: "FK_ProdutoEmbalagens_DefSituacaoProdutoEmbalagem_SituacaoProdutoEmbalagemID",
                        column: x => x.SituacaoProdutoEmbalagemID,
                        principalTable: "DefSituacaoProdutoEmbalagem",
                        principalColumn: "SituacaoProdutoEmbalagemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoEmbalagemID = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(120)", nullable: false),
                    SituacaoProdutoID = table.Column<int>(type: "int", nullable: false),
                    UnidadeComercialID = table.Column<int>(type: "int", nullable: false),
                    PesoLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                    table.ForeignKey(
                        name: "FK_Produtos_DefSituacaoProduto_SituacaoProdutoID",
                        column: x => x.SituacaoProdutoID,
                        principalTable: "DefSituacaoProduto",
                        principalColumn: "SituacaoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_DefUnidadeComercial_UnidadeComercialID",
                        column: x => x.UnidadeComercialID,
                        principalTable: "DefUnidadeComercial",
                        principalColumn: "UnidadeComercialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_ProdutoEmbalagens_ProdutoEmbalagemID",
                        column: x => x.ProdutoEmbalagemID,
                        principalTable: "ProdutoEmbalagens",
                        principalColumn: "ProdutoEmbalagemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEmbalagens_SituacaoProdutoEmbalagemID",
                table: "ProdutoEmbalagens",
                column: "SituacaoProdutoEmbalagemID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoEmbalagemID",
                table: "Produtos",
                column: "ProdutoEmbalagemID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_SituacaoProdutoID",
                table: "Produtos",
                column: "SituacaoProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UnidadeComercialID",
                table: "Produtos",
                column: "UnidadeComercialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "DefSituacaoProduto");

            migrationBuilder.DropTable(
                name: "DefUnidadeComercial");

            migrationBuilder.DropTable(
                name: "ProdutoEmbalagens");

            migrationBuilder.DropTable(
                name: "DefSituacaoProdutoEmbalagem");
        }
    }
}
