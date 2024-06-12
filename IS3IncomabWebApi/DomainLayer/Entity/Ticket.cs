namespace IS3IncomabWebApi.DomainLayer.Entity
{
    public class Ticket
    {
        public int Id { get; set; }
        public int IsOmitted { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateBy { get; set; }
        public DateTime ModifyBy { get; set; }
    }
}
