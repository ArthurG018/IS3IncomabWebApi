namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class SourceMainDTO
    {
        public CustomerDto? Customer { get; set; }
        public CylinderDto? Cylinder { get; set; }
        public DetailTicketCylinderDto? DetailTicketCylinder { get; set; }
        public TicketDto? Ticket { get; set; }
    }
}
