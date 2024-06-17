using System.ComponentModel.DataAnnotations;

namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public String IdentityCard { get; set; }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public String FullName { get; set; }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public String? Phone { get; set; }
        public String? Address { get; set; }
        public int IsWholeSaler { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public String? NameCreate { get; set; }
        public String? NameModify { get; set; }
    }
}
