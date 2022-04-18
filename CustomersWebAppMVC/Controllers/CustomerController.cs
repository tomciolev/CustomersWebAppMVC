using CustomersWebAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomersWebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        private static IList<CustomerModel> customers = new List<CustomerModel>()
        {
            new CustomerModel(){Id = 1, Name = "Tomek", VAT="321312", PhoneNumber="123123", City="Krakow"},
            new CustomerModel(){Id = 2, Name = "Kuba", VAT="321312", PhoneNumber="123123", City="Krakow"}
        };
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View(customers.SingleOrDefault(x => x.Id == id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customerModel)
        {
            customerModel.Id = customers.Count + 1;
            customers.Add(customerModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
