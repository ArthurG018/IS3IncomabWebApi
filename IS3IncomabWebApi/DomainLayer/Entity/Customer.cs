namespace IS3IncomabWebApi.DomainLayer.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public String? IdentityCard { get; set; }
        public String? FullName { get; set; }
        public String? Phone {  get; set; }
        public String? Address {  get; set; }
        public int IsWholeSaler { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }
    }
}
