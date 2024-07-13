namespace IS3IncomabWebApi.DomainLayer.Entity
{
    public class Ticket
    {
        public int Id { get; set; }
        public string NumberOfPart {  get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }
    }
}
