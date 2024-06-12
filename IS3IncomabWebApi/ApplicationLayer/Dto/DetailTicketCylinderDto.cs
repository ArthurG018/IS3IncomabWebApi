namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class DetailTicketCylinderDto
    {
        public int Id { get; set; }
        public int IsWarranty { get; set; }
        public int IsReturned { get; set; }
        public int Amount { get; set; }
        public int CylinderId { get; set; }
        public int TicketId { get; set; }
    }
}
