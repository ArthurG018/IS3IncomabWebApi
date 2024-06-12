using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ITicketRepository
    {
        bool Insert(Ticket ticket);
        bool Update(Ticket ticket);
        bool Delete(int ticketId);
        Ticket Get(int ticketId);
        IEnumerable<Ticket> GetAll();
    }
}
