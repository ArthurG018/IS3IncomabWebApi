using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ITicketDomain
    {
        public IEnumerable<Ticket> GetCustomerId(int customerId);
        int Insert(Ticket ticket);
        bool Update(Ticket ticket);
        IEnumerable<Ticket> GetAll();
    }
}
