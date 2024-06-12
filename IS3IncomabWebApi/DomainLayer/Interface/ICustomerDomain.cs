using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICustomerDomain
    {
        IEnumerable<Customer> GetAll();
    }
}
