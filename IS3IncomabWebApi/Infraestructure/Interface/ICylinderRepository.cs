using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.DomainLayer.Interface
{
    public interface ICylinderRepository
    {
        bool Insert(Cylinder cylinder);
        bool Update(Cylinder cylinder);
        bool DeleteLogic(Cylinder cylinder);
        Cylinder Get(int cylinderId);
        IEnumerable<Cylinder> GetAll();
    }
}
