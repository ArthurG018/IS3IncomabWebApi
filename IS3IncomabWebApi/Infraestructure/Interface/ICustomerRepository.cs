using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICustomerRepository
    {
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(int customerId);
        Customer Get(int customerId);
        IEnumerable<Customer> GetAll();
    }
}
