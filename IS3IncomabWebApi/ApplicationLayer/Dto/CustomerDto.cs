using System.ComponentModel.DataAnnotations;

namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public String? IdentityCard { get; set; }
        public String? FullName { get; set; }
        public String? Phone { get; set; }
        public String? Address { get; set; }
        public int IsMayorist { get; set; }
        public int IsJuridicPerson { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ModifyDate { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }
        public int StartIndex {  get; set; }
        public int MaxRecord {  get; set; }
        public int TotalRecords { get; set; }
    }
}
