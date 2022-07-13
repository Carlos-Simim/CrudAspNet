using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class Produto
    {
       

        [Key]
        //[DisplayName("Código")]
        public int ProdutoID { get; set; }

        /*[ForeignKey("ProdutoEmbalagemID")]
        public virtual ProdutoEmbalagem ProdutoEmbalagem { get; set; }*/

        [Column(TypeName = "varchar(120)")]
        //[DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ForeignKey("SituacaoProdutoID")]
       //[DisplayName("Situação")]
        public virtual DefSituacaoProduto DefSituacaoProduto { get; set;}

        [ForeignKey("UnidadeComercialID")]
        //[DisplayName("Unidade comercial")]
        public virtual DefUnidadeComercial DefUnidadeComercial { get; set;}

        //[DisplayName("Peso Líquido")]
        public decimal PesoLiquido { get; set; }

    }
}
