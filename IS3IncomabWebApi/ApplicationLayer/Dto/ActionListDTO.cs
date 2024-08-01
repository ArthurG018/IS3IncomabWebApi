using IS3IncomabWebApi.DomainLayer.StaticClass.Record;

namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class ActionListDTO
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public String Number { get; set; }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int IsActive { get; set; }
        public int? CreateBy { get; set; }
        public int? ModifyBy { get; set; }

        //Object Record
        public Status Status { get; set; }
        public TypeCylinder TypeCylinder { get; set; }

        /*Name Users*/
        public String? NameCreate { get; set; }
        public String? NameModify { get; set; }
    }
}
