using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface ICustomerDto
    {
        Response<IEnumerable<CustomerDto>> GetAll(int StartIndex, int MaxRecord, string filter);
    }
}
