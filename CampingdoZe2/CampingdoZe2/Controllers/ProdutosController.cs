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

        public ActionResult Detalhes(int id)
        {
            var produto = _context.Produtos.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

    }
}