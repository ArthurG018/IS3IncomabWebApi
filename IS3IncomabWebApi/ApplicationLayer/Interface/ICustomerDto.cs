using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface ICustomerDto
    {
        Response<IEnumerable<CustomerDto>> GetAll(int StartIndex, int MaxRecord, string filter);
        Response<bool> Update(CustomerDto customerDto);
        Response<bool> DeleteLogic(int customerId, int userId);
        Response<bool> Insert(CustomerDto cylinderDto);
        Response<CustomerDto> Get(int customerId);
        Response<bool> ValidIdentityCard(string identityCard);
    }
}
