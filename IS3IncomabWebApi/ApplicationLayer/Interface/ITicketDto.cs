using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface ITicketDto
    {
        public Response<IEnumerable<TicketDto>> GetCustomerId(int customerId);
        public Response<int> InsertOrUpdtae(TicketDto ticketDto);

    }
}
