using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICustomerDomain
    {
       
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool DeleteLogic(Customer customer);
        Customer Get(int customerId);
        IEnumerable<Customer> GetAll();
    }
}
