using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class TicketMain : ITicketDto
    {
        private readonly ITicketDomain _ticketDomain;
        private readonly IMapper _mapper;

        public TicketMain(ITicketDomain ticketDomain, IMapper mapper)
        {
            _ticketDomain = ticketDomain;
            _mapper = mapper;
        }

        public Response<IEnumerable<TicketDto>> GetCustomerId(int customerId)
        {
            var response = new Response<IEnumerable<TicketDto>>();
            try
            {
                var ticket = _ticketDomain.GetCustomerId(customerId);
                response.Data = _mapper.Map<IEnumerable<TicketDto>>(ticket);
                if (response.Data != null)
                {
                    response.Message = "Consulta Exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<int> InsertOrUpdtae(TicketDto ticketDto)
        {
            var response = new Response<int>();

            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDto);

                if (ticketDto.Id == 0)
                {
                    if (getNumberOfPartEmptyTicket(ticket.NumberOfPart)){
                        
                        response.Data = _ticketDomain.Insert(ticket);
                        response.Message = "El ticket se ha registrado con éxito"; 
                        response.IsSuccess = true;
                    }
                    else
                    {

                        response.Message = "Ya se tiene registrado una boleta con Número de Parte: " + ticket.NumberOfPart + ". Por favor, verificarlo.";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    _ticketDomain.Update(ticket);
                    response.Message = "El cliente se ha editado con éxito";
                    response.IsSuccess = true;
                }

            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }

            return response;
        }
        public bool getNumberOfPartEmptyTicket(string numberOfPart)
        {
            return (_ticketDomain.GetAll().Where(x => x.NumberOfPart.Equals(numberOfPart)).ToList().Count() < 1);
        }
    }
}
