using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class CylinderMain : ICylinderDto
    {
        private readonly ICylinderDomain _cylinderDomain;
        private readonly IMapper _mapper;

        public CylinderMain(ICylinderDomain cylinderDomain, IMapper mapper)
        {
            _cylinderDomain = cylinderDomain;
            _mapper = mapper;
        }

        public Response<IEnumerable<CylinderDto>> GetAll()
        {
            var response = new Response<IEnumerable<CylinderDto>>();
            try
            {
                var cylinders = _cylinderDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CylinderDto>>(cylinders);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSucces = false;
            }
            return response;
        }
    }
}
