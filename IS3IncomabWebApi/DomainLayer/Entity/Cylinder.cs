namespace IS3IncomabWebApi.DomainLayer.Entity
{
    public class Cylinder
    {
        public int Id { get; set; }
        public String? Number { get; set; }
        public int StatusId { get; set; }
        public int TypeCylinderId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ModifyDate { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }
    }
}
