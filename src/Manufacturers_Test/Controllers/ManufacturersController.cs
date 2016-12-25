using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Manufacturers_Test.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Manufacturers_Test.Controllers
{
    public class ManufacturersController : Controller
    {
        private StoreContext _context;
        public ManufacturersController(StoreContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Manufacturers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        public IActionResult Details (int id)
        {
            var manufacturer = _context.Manufacturers.Find(id);
            ManufacturerViewModel vm = new ManufacturerViewModel();
            vm.ManufacturerId = manufacturer.ManufacturerId;
            vm.ManufacturerName = manufacturer.ManufacturerName;
            vm.products = _context.Products.Where(o => o.ManufacturerId == id);
            return View(vm);
        }

        [ActionName("Delete")]
        public IActionResult Delete (int? id)
        {
            Manufacturer m = _context.Manufacturers.First(o => o.ManufacturerId == id);
            if (m != null)
            {
                return View(m);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Manufacturer m = _context.Manufacturers.First(o => o.ManufacturerId == id);
            _context.Manufacturers.Remove(m);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
