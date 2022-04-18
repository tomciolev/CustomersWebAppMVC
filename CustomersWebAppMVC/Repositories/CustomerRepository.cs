using CustomersWebAppMVC.Models;
using System.Linq;

namespace CustomersWebAppMVC.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(CustomerModel customer)
        {
            
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CustomerModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public CustomerModel GetCustomer(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, CustomerModel customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
