using CadastroProdutos.Models;
using static CadastroProdutos.Models.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using WebMatrix.Data;

namespace CadastroProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _contexto;

        public ProdutosController(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public IActionResult Index()
        {
            var produtos = _contexto.Produtos.Include(p => p.DefSituacaoProduto);
            
            return View( produtos.ToList());
        }

        [HttpGet]
        public IActionResult CriarProduto()
        {            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult CriarProduto(Produto produto, ProdutoEmbalagem embalagem)
        {         
            
            _contexto.Add(produto);            
            _contexto.SaveChanges();

            if (embalagem.DefSituacaoProdutoEmbalagemId != 1 && embalagem.DefSituacaoProdutoEmbalagemId != 2)
            {
                if (produto.VerificarEmbalagem(_contexto) == false)
                {
                    ProdutoEmbalagem embalagem2 = new ProdutoEmbalagem
                    {
                        DefSituacaoProdutoEmbalagemId = 1,
                        ProdutoId = produto.ProdutoId,
                        FatorDeConversao = 1
                    };

                    _contexto.Add(embalagem2);
                    _contexto.SaveChanges();
                }
            }
            else
            {
                embalagem.ProdutoId = produto.ProdutoId;
                _contexto.Add(embalagem);
                _contexto.SaveChanges();
            }

            

            return RedirectToAction(nameof(Index));

        }

        public IActionResult DetalhesProduto (int? id)
        {
            Produto produto = _contexto.Produtos.Find(id);
            return View(produto);
        }

        [HttpGet]
        public IActionResult AtualizarProduto(int? id)
        {
            
            Produto produto = _contexto.Produtos.Find(id);
            return View(produto);
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task <IActionResult> AtualizarProduto(int? id, Produto produto)
        {
            
            _contexto.Update(produto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            

        }
        
        [HttpGet]        
        public IActionResult ExcluirProduto(int? id)
        {            
            var produto = _contexto.Produtos.Find(id);

            return View(produto);           

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult ExcluirProduto(Produto produto)
        {
            
            _contexto.Remove(produto);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }


    }
}
