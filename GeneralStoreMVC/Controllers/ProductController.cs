using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class ProductController : Controller
    {
        // Add the application DB Context (link to the database)
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(_dbContext.Products.ToList());
        }

        // Get: Product
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET : Delete
        // Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product product = _dbContext.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST : Delete
        // Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product product = _dbContext.Products.Find(id);

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET : Edit
        // Product/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST : Edit
        // Product/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}