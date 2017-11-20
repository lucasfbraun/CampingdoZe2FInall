using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CampingdoZe2.Models;
using System.Data.Entity;
using CampingdoZe2.ViewModels;

namespace CampingdoZe2.Controllers
{
    public class CustomersController : Controller
    {
       private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var cliente = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }
        public ActionResult Edit(int id)
        {
            var cliente = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
              Customers = cliente

            };

            return View("CustomerForm", viewModel);
        }
        [HttpPost] // só será acessada com POST
        public ActionResult Save(Customer cliente)
        {
            if (cliente.Id == 0)
            {
                _context.Customers.Add(cliente);
            }
            else
            {
                var clienteInDb = _context.Customers.Single(c => c.Id == cliente.Id);

                clienteInDb.Nome = cliente.Nome;
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {

            };

            return View("CustomerForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var cliente = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            _context.Customers.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}