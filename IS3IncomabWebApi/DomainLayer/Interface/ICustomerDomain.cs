using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICustomerDomain
    {
       
        bool Insert(Customer cylinder);
        bool Update(Customer cylinder);
        bool DeleteLogic(Customer cylinder);
        Customer Get(int cylinderId);
        IEnumerable<Customer> GetAll();
    }
}
