using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.DomainLayer.Core
{
    public class TicketDomain : ITicketDomain
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketDomain(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IEnumerable<Ticket> GetCustomerId(int customerId)
        {
            return _ticketRepository.GetCustomerId(customerId);
        }

        public int Insert(Ticket ticket)
        {
            return _ticketRepository.Insert(ticket);
        }

        public bool Update(Ticket ticket)
        {
            return _ticketRepository.Update(ticket);
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }
    }
}
