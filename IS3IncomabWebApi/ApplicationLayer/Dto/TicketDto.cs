namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int IsOmitted { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateBy { get; set; }
        public DateTime ModifyBy { get; set; }
    }
}
