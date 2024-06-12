using IS3IncomabWebApi.DomainLayer.StaticClass.Record;

namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class CylinderDto
    {
        public int Id { get; set; }
        public String? Number { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime ModifyDate { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }

        //Object Record
        public Status Status { get; set; }
        public TypeCylinder typeCylinder { get; set; }
    }
}
