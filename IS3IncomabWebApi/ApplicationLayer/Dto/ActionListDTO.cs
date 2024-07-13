using IS3IncomabWebApi.DomainLayer.StaticClass.Record;

namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class ActionListDTO
    {
        public CylinderDto? Cylinder { get; set; }
        public Status Status { get; set; }
        public TypeCylinder TypeCylinder { get; set; }
    }
}
