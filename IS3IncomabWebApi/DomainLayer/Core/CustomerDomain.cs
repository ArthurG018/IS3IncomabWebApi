using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.DomainLayer.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDomain(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool DeleteLogic(Customer customer)
        {
            return _customerRepository.DeleteLogic(customer);  
        }

        public Customer Get(int cylinderId)
        {
            return _customerRepository.Get(cylinderId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public bool Insert(Customer customer)
        {
            return _customerRepository.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}
