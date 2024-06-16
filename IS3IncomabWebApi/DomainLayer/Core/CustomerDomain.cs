using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.DomainLayer.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserIncomabRepository _userIncomabRepository;

        public CustomerDomain(ICustomerRepository customerRepository, IUserIncomabRepository userIncomabRepository)
        {
            _customerRepository = customerRepository;
            _userIncomabRepository = userIncomabRepository;
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

        public bool Insert(Customer cylinder)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}
