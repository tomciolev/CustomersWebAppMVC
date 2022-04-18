using CustomersWebAppMVC.Models;
using System;
using System.Linq;

namespace CustomersWebAppMVC.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;
        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public void Add(CustomerModel customer)
        {
            customer.Id = _customerContext.Customers.Count() + 1;
            customer.CreationDate = DateTime.Now;
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _customerContext.Customers.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                _customerContext.Customers.Remove(result);
                _customerContext.SaveChanges();
            } 
        }

        public IQueryable<CustomerModel> GetAll()
        {
            return _customerContext.Customers;
        }

        public CustomerModel GetCustomer(int id)
        {
            return _customerContext.Customers.SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id, CustomerModel customer)
        {
            var result = _customerContext.Customers.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.VAT = customer.VAT;
                result.Name = customer.Name;
                result.Street = customer.Street;
                result.StreetNumber = customer.StreetNumber;
                result.PhoneNumber = customer.PhoneNumber;
                result.City = customer.City;
                result.PostalCode = customer.PostalCode;
                _customerContext.SaveChanges();
            }
        }
    }
}
