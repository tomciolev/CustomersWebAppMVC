using CustomersWebAppMVC.Models;
using CustomersWebAppMVC.Repositories;
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
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET: Customer
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_customerRepository.GetAll().Where(s => s.Name.Contains(searchString)).ToList());
            }
            else
                return View(_customerRepository.GetAll());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(_customerRepository.GetCustomer(id));
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
            _customerRepository.Add(customerModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_customerRepository.GetCustomer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            _customerRepository.Update(id, customer);
              
            return RedirectToAction(nameof(Index));
                      
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_customerRepository.GetCustomer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerModel customer)
        {
            _customerRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
