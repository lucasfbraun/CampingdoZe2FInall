using CampingdoZe2.Models;
using CampingdoZe2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampingdoZe2.Controllers
{
    public class TipoProdutoController : Controller
    {
        private ApplicationDbContext _context;

        public TipoProdutoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var tipoproduto = _context.Produtos.ToList();

            return View(tipoproduto);
        }

        public ActionResult Details(int id)
        {
            var tipoproduto = _context.TipoProdutos.SingleOrDefault(c => c.Id == id);

            if (tipoproduto == null)
                return HttpNotFound();

            return View(tipoproduto);
        }
        public ActionResult Edit(int id)
        {
            var tipoproduto = _context.TipoProdutos.SingleOrDefault(c => c.Id == id);

            if (tipoproduto == null)
                return HttpNotFound();

            var viewModel = new TipoProdutoFormViewModel
            {
                TipoProduto = tipoproduto

            };

            return View("TipoProdutoForm", viewModel);
        }
        [HttpPost] // só será acessada com POST
        public ActionResult Save(TipoProduto tipoproduto)
        {
            if (tipoproduto.Id == 0)
            {
                _context.TipoProdutos.Add(tipoproduto);
            }
            else
            {
                var customerInDb = _context.Produtos.Single(c => c.Id == tipoproduto.Id);

                customerInDb.Nome = tipoproduto.Nome;
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        public ActionResult New()
        {

            var viewModel = new TipoProdutoFormViewModel
            {
                TipoProduto = new TipoProduto()
            };

            return View("TipoProdutoForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var tipoproduto = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (tipoproduto == null)
                return HttpNotFound();

            _context.Customers.Remove(tipoproduto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}