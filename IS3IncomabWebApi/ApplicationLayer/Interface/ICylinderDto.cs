using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface ICylinderDto
    {
        Response<int> Insert(CylinderDto cylinderDto);
        Response<IEnumerable<CylinderDto>> GetAll(int StartIndex, int MaxRecord, string filter);
        Response<bool> Update(CylinderDto cylinderDto);
        Response<bool> DeleteLogic(int cylinderId, int userId);
        Response<CylinderDto> GetId(int cylinderId);
        public bool ValidNumberCylinder(string num);
    }
}
