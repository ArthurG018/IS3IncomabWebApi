using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICylinderDomain
    {
        int Insert(Cylinder cylinder);
        bool Update(Cylinder cylinder);
        bool DeleteLogic(Cylinder cylinder);
        Cylinder GetId(int cylinderId);
        IEnumerable<Cylinder> GetAll();
    }
}
