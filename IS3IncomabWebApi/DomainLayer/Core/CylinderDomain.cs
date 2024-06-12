using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.DomainLayer.Core
{
    public class CylinderDomain : ICylinderDomain
    {
        private readonly ICylinderRepository _cylinderRepository;

        public CylinderDomain(ICylinderRepository cylinderRepository)
        {
            _cylinderRepository = cylinderRepository;
        }

        public IEnumerable<Cylinder> GetAll()
        {
            return _cylinderRepository.GetAll();
        }
    }
}
