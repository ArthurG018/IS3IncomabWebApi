using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Core;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class DetailTicketCylinderMain : IDetailTicketCylinderDto
    {
        private readonly IDetailTicketCylinderDomain _detailTicketCylinderDomain;
        private readonly IMapper _mapper;

        public DetailTicketCylinderMain(IDetailTicketCylinderDomain detailTicketCylinderDomain, IMapper mapper)
        {
            _detailTicketCylinderDomain = detailTicketCylinderDomain;
            _mapper = mapper;
        }

        public Response<bool> Insert(DetailTicketCylinderDto detailTicketCylinder)
        {
            var response = new Response<bool>();
            try
            {
                var details = _mapper.Map<DetailTicketCylinder>(detailTicketCylinder);

                response.Data = _detailTicketCylinderDomain.Insert(details);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
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
