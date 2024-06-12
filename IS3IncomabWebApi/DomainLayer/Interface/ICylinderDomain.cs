using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICylinderDomain
    {
        IEnumerable<Cylinder> GetAll();
    }
}
