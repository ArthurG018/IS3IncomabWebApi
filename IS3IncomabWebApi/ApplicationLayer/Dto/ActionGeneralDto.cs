namespace IS3IncomabWebApi.ApplicationLayer.Dto
{
    public class ActionGeneralDto
    {
        public SourceMainDTO sourceMainDTO {  get; set; }
        public IEnumerable<ActionListDTO> actionListDTOsDG {  get; set; }
        public IEnumerable<ActionListDTO> actionListDTOsSale {  get; set; }
        public IEnumerable<ActionListDTO> actionListDTOsWarranty {  get; set; }
    }
}
