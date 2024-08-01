namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class ActionGeneralDto
    {
        public SourceMainDTO sourceMainDTO {  get; set; }
        public IEnumerable<CylinderDto> actionListDTOsDG {  get; set; }
        public IEnumerable<CylinderDto> actionListDTOsSale {  get; set; }
        public IEnumerable<CylinderDto> actionListDTOsWarranty {  get; set; }
    }
}
