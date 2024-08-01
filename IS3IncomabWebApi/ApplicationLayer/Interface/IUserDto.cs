using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface IUserDto
    {
        Response<UserDto> GetUser(string user, string psw);
    }
}
