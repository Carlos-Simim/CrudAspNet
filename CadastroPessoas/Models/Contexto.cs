using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Models
{
    public class Contexto : DbContext
    {
        public DbSet <Produto> Produtos { get; set; }
        public DbSet <ProdutoEmbalagem> ProdutoEmbalagens { get; set; } 
        public DbSet <DefSituacaoProduto> DefSituacaoProduto { get; set; }
        public DbSet <DefUnidadeComercial> DefUnidadeComercial { get; set; }
        public DbSet <DefSituacaoProdutoEmbalagem> DefSituacaoProdutoEmbalagem { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
