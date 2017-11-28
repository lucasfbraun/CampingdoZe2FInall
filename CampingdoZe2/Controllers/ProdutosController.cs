using CampingdoZe2.Models;
using CampingdoZe2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampingdoZe2.Controllers
{
    public class ProdutosController : Controller
    {
        private ApplicationDbContext _context;

        public ProdutosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var produtos = _context.Produtos.ToList();

            return View(produtos);
        }

        public ActionResult Details(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }
        public ActionResult Edit(int id)
        {
            var produto= _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            var viewModel = new ProdutoFormViewModels
            {
                Produto = produto

            };

            return View("ProdutoForm", viewModel);
        }
        [HttpPost] // só será acessada com POST
        public ActionResult Save(Produto produto)
        {
            if (produto.Id == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                var produtoInDb = _context.Produtos.Single(c => c.Id == produto.Id);

                produtoInDb.Nome = produto.Nome;
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        public ActionResult New()
        {

            var viewModel = new ProdutoFormViewModels
            {
                Produto = new Produto()
            };

            return View("ProdutoForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}