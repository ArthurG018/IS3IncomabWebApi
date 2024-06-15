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

        public bool Delete(int cylinderId)
        {
            throw new NotImplementedException();
        }

        public Cylinder Get(int cylinderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cylinder> GetAll()
        {
            return _cylinderRepository.GetAll();
        }

        public bool Insert(Cylinder cylinder)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cylinder cylinder)
        {
            return _cylinderRepository.Update(cylinder);
        }
    }
}
