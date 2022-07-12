using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class DefSituacaoProduto
    {

        [Key]
        public int SituacaoProdutoId { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string DescricaoSituacao { get; set; }

    }
}