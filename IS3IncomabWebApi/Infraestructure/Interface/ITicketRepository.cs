using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ITicketRepository
    {
        int Insert(Ticket ticket);
        bool Update(Ticket ticket);
        bool Delete(int ticketId);
        Ticket Get(int ticketId);
        IEnumerable<Ticket> GetAll();
        public IEnumerable<Ticket> GetCustomerId(int customerId);
    }
}
