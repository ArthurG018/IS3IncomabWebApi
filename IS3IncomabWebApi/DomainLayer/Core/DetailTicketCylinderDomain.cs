using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.DomainLayer.Core
{
    public class DetailTicketCylinderDomain : IDetailTicketCylinderDomain
    {

        private readonly IDetailTicketCylinderRepository _detailTicketCylinder;

        public DetailTicketCylinderDomain(IDetailTicketCylinderRepository detailTicketCylinder)
        {
            _detailTicketCylinder = detailTicketCylinder;
        }

        public bool Insert(DetailTicketCylinder detailTicketCylinder)
        {
            return _detailTicketCylinder.Insert(detailTicketCylinder);
        }
    }
}
