using CampingdoZe2.Models;
using CampingdoZe2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var clientes = _context.Customers.ToList();

            return View(clientes);
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
                Customer = cliente

            };

            return View("FormCustomer", viewModel);
        }
        [HttpPost] // só será acessada com POST
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Produtos.Single(c => c.Id == customer.Id);

                customerInDb.Nome = customer.Nome;
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
                Customer = new Customer()
            };

            return View("FormCustomer", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}