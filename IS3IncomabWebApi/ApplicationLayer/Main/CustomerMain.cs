using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Core;
using IS3IncomabWebApi.DomainLayer.Interface;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class CustomerMain : ICustomerDto
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;

        public CustomerMain(ICustomerDomain customerDomain, IMapper mapper)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
        }

        public Response<IEnumerable<CustomerDto>> GetAll(int StartIndex, int MaxRecord)
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = _customerDomain.GetAll();
                response.Data = PageCustomer(StartIndex, MaxRecord, _mapper.Map<List<CustomerDto>>(customers));
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSucces = false;
            }
            return response;
        }
        /*Function for pagination*/
        public IEnumerable<CustomerDto> PageCustomer(int StartIndex, int MaxRecord, List<CustomerDto> data )
        {
            data[0].TotalRecords = data.Count;
            var response = data.Skip(StartIndex).Take(MaxRecord);
            
            return response;
        }

    }
}
