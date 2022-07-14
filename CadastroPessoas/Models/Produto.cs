using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class Produto
    {
       
        [Key]
        public int ProdutoId { get; set; }

        [Column(TypeName = "varchar(120)")]
        public string Descricao { get; set; }

        [ForeignKey("DefSituacaoProduto")]
        public virtual DefSituacaoProduto DefSituacaoProdutoId { get; set;}
       
        [ForeignKey("UnidadeComercialID")]
        public virtual DefUnidadeComercial DefUnidadeComercial { get; set;}

        public decimal PesoLiquido { get; set; }

    }
}
