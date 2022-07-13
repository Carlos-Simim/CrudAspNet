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
            
            var embalagens = _contexto.ProdutoEmbalagens.Include(x => x.DefSituacaoProdutoEmbalagem);
            var embalagens2 = _contexto.ProdutoEmbalagens.Include(y => y.Produto);

            ViewData["ProdutoEmbalagens"] = embalagens.ToList();
            ViewData["ProdutoEmbalagens2"] = embalagens2.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CriarProduto(string Descricao, int DefSituacaoProduto, int DefUnidadeComercial, decimal PesoLiquido)
        {
            
            _contexto.Database.ExecuteSqlRaw("Insert into Produtos Values({0},{1},{2},{3})", Descricao, DefSituacaoProduto, DefUnidadeComercial, PesoLiquido);
            
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult AtualizarProduto(int? id)
        {
            if (id != null)
            {
                Produto produto = _contexto.Produtos.Find(id);
                return View(produto);
            }

            else return NotFound();

        }
        
        [HttpPost]
        public async Task <IActionResult> AtualizarProduto(int? id, Produto produto)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _contexto.Update(produto);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else return View(produto);
            }

            else return NotFound();

        }

        [HttpGet]
        public IActionResult ExcluirProduto(int? id)
        {

            var produto = _contexto.Produtos.Find(id);
            return View(produto);
           

        }

        [HttpPost]
        public async Task<IActionResult> ExcluirProduto(int? id, Produto produto)
        {
            if (id != null)
            {
                _contexto.Remove(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            else return NotFound();

        }


    }
}
