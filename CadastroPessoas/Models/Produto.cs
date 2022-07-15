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

        public virtual DefSituacaoProduto DefSituacaoProduto { get; set;}
        public int DefSituacaoProdutoId { get; set; }
       
        public virtual DefUnidadeComercial DefUnidadeComercial { get; set;}
        public int DefUnidadeComercialId { get; set; }

        public virtual ICollection <ProdutoEmbalagem> ProdutoEmbalagems { get; set; }

        public decimal PesoLiquido { get; set; }

    }
}
