using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.DomainLayer.Core
{
    public class UsersDomain : IUserIncomabDomain
    {
        private readonly IUserIncomabRepository _userIncomabRepository;

        public UsersDomain(IUserIncomabRepository userIncomabRepository)
        {
            _userIncomabRepository = userIncomabRepository;
        }

        public UserIncomab Get(int userIncomabId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserIncomab> GetAll()
        {
            return _userIncomabRepository.GetAll();
        }
    }
}
