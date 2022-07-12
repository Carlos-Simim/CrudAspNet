using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class DefSituacaoProdutoEmbalagem
    {

        [Key]
        public int SituacaoProdutoEmbalagemID { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string DescricaoSituacao { get; set; }

    }
}