using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface IMainFlowDto
    {
        Response<List<string>> ActionGeneral(SourceMainDTO sourceMainDTO,
                                        IEnumerable<CylinderDto> actionListDTOsDG,
                                        IEnumerable<CylinderDto> actionListDTOsSale,
                                        IEnumerable<CylinderDto> actionListDTOsWarranty);
    }
}
