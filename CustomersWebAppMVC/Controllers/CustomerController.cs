using CustomersWebAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        // GET: Customer
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(customers.Where(s => s.Name.Contains(searchString)).ToList());
            }
            else
                return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(customers.SingleOrDefault(x => x.Id == id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customerModel)
        {
            customerModel.Id = customers.Count + 1;
            customerModel.CreationDate = DateTime.Now;
            customers.Add(customerModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customers.SingleOrDefault(x => x.Id == id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            var result = customers.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
                result.VAT = customer.VAT;
                result.Name = customer.Name;
                result.Street = customer.Street;
                result.StreetNumber = customer.StreetNumber;
                result.PhoneNumber = customer.PhoneNumber;
                result.City = customer.City;
                result.PostalCode = customer.PostalCode;
            }
            
            return RedirectToAction(nameof(Index));
                      
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(customers.SingleOrDefault(x => x.Id == id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerModel customer)
        {
            var result = customers.SingleOrDefault(x => x.Id == id);
            customers.Remove(result);
            return RedirectToAction(nameof(Index));
        }
    }
}
