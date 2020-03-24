using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        // Add the application DB Context (link to the database)
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customerList = _dbContext.Customers.ToList();
            List<Customer> orderedList = customerList.OrderBy(customer => customer.LastName).ToList();
            return View(orderedList);
        }
    }
}