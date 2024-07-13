namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string NumberOfPart { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public int CreateBy { get; set; }
        public int ModifyBy { get; set; }
    }
}
