using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class DefUnidadeComercial
    {

        [Key]        
        public int UnidadeComercialID { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}