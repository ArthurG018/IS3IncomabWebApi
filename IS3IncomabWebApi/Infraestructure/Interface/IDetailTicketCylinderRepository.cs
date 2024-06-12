using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface IDetailTicketCylinderRepository
    {
        bool Insert(DetailTicketCylinder detailTicketCylinder);
        bool Update(DetailTicketCylinder detailTicketCylinder);
        bool Delete(int detailTicketCylinderId);
        DetailTicketCylinder Get(int detailTicketCylinderId);
        IEnumerable<DetailTicketCylinder> GetAll();
    }
}
