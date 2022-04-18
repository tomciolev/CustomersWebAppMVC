using CustomersWebAppMVC.Models;
using System.Linq;

namespace CustomersWebAppMVC.Repositories
{
    public interface ICustomerRepository
    {
        CustomerModel GetCustomer(int id);
        IQueryable<CustomerModel> GetAll();
        void Add(CustomerModel customer);
        void Update(int id, CustomerModel customer);
        void Delete(int id);
    }
}
