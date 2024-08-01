using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface IUserIncomabRepository
    {
        bool Insert(UserIncomab userIncomab);
        bool Update(UserIncomab userIncomab);
        bool Delete(int userIncomabId);
        UserIncomab Get(int userIncomabId);
        IEnumerable<UserIncomab> GetAll();
        UserIncomab GetUser(string user, string psw);
    }
}
