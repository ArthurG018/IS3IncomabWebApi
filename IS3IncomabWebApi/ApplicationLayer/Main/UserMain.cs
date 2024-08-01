using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class UserMain : IUserDto
    {
        private readonly IUserIncomabDomain _userIncomabDomain;
        private readonly IMapper _mapper;

        public UserMain(IUserIncomabDomain userIncomabDomain, IMapper mapper)
        {
            _userIncomabDomain = userIncomabDomain;
            _mapper = mapper;
        }

        public Response<UserDto> GetUser(string user, string psw)
        {
            var response = new Response<UserDto>();
            try
            {
                var userIncomab = _userIncomabDomain.GetUser(user, psw);
                if (userIncomab != null)
                {
                    response.Data = _mapper.Map<UserDto>(userIncomab);
                    response.IsSuccess = true;
                    response.Message = "Consulta éxitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
