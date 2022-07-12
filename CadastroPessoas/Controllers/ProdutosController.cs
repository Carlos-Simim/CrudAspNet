using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult CriarProduto(string Descricao, int DefSituacaoProduto, int DefUnidadeComercial, decimal PesoLiquido)
        {

            /*_contexto.Add(produto);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Index));*/

            var novoProduto = new Produto()
            {
                Descricao = Descricao,
                SituacaoProdutoId = DefSituacaoProduto,
                DefUnidadeComercial = DefUnidadeComercial,
                PesoLiquido = PesoLiquido,
            };



            /*novoProduto.Descricao = Descricao;
            novoProduto.DefSituacaoProduto = DefSituacaoProduto;
            novoProduto.DefUnidadeComercial = DefUnidadeComercial;
            novoProduto.PesoLiquido = PesoLiquido;*/
            


            _contexto.Add(novoProduto);
            _contexto.SaveChanges();
            
            /*var db = Database.Open("CadastroProdutos");
            var insertCommand = "INSERT INTO Produtos VALUES (@0, @1, @2, @3)";
            db.Execute(insertCommand, Descricao, DefSituacaoProduto, DefUnidadeComercial, PesoLiquido);*/
            //return RedirectToAction(nameof(Index));

            /*
             var db = Database.Open("WebPagesMovies");
            var insertCommand = "INSERT INTO Movies (Title, Genre, Year) VALUES(@0, @1, @2)";
            db.Execute(insertCommand, title, genre, year);
            */

            return Content($"Descrição: {Descricao}\nSituação: {DefSituacaoProduto}\nUnidade: {DefUnidadeComercial}\nPeso: {PesoLiquido}");
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
            if (id != null)
            {
                Produto produto = _contexto.Produtos.Find(id);
                return View(produto);
            }

            else return NotFound();

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
