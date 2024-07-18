using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface IMainFlowDto
    {
        Response<List<string>> ActionGeneral(SourceMainDTO sourceMainDTO,
                                        IEnumerable<ActionListDTO> actionListDTOsDG,
                                        IEnumerable<ActionListDTO> actionListDTOsSale,
                                        IEnumerable<ActionListDTO> actionListDTOsWarranty);
    }
}
