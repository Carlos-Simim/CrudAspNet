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
        public IActionResult CriarProduto(Produto produto)
        {
            _contexto.Add(produto);
            _contexto.SaveChanges();

            produto.VerificarEmbalagem(_contexto);

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
        public async Task <IActionResult> AtualizarProduto(int? id, Produto produto)
        {
            if (id != null)
            {
                _contexto.Update(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
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
