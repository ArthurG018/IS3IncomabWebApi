using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface IUserIncomabDomain
    {
        UserIncomab Get(int userIncomabId);
        IEnumerable<UserIncomab> GetAll();
        UserIncomab GetUser(string user, string psw);
    }
}
