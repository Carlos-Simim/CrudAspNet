﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class ProdutoEmbalagem
    {
        [Key]
        public int ProdutoEmbalagemID { get; set; }

        public virtual DefSituacaoProdutoEmbalagem DefSituacaoProdutoEmbalagem { get; set; }

        public int DefSituacaoProdutoEmbalagemId { get; set; }

        public virtual Produto Produto { get; set; }

        public int ProdutoId { get; set; }

        public decimal FatorDeConversao { get; set; }

    }
}