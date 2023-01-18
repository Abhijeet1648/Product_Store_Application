using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Store.Data;
using Product_Store.Models;

namespace Product_Store.Controllers
{
    public class ProductController : Controller
    {
        public ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var pro = _context.products.ToList();
            return View(pro);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var pro = _context.products.Find(id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var pro = _context.products.Find(id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        [HttpPost]
        
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                _context.products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var pro = _context.products.Find(id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.products.Remove(product);
            _context.SaveChanges();
            TempData["Deleted"] = "Product Deleted Successfully !";
            return RedirectToAction("Index");
        }

    }
}
