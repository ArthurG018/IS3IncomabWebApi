using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Interface;
using Microsoft.IdentityModel.Tokens;

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

        public Response<IEnumerable<CustomerDto>> GetAll(int StartIndex, int MaxRecord, string filter)
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customers = _customerDomain.GetAll();
                var customersFilter = FilterCustomer(_mapper.Map<List<CustomerDto>>(customers), filter);
                response.Data = PageCustomer(StartIndex, MaxRecord, customersFilter);
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
            if (data.IsNullOrEmpty()) return data;
            data[0].TotalRecords = data.Count;
            if(MaxRecord.Equals(0)) return data;
            var response = data.Skip(StartIndex).Take(MaxRecord);
            
            return response;
        }

        /*Function for Filter*/
        public List<CustomerDto> FilterCustomer(List<CustomerDto> data, string filter)
        {
            if (filter.IsNullOrEmpty()) return data;
            data = (from d in data where d.FullName.Contains(filter.ToUpper()) || d.IdentityCard.Contains(filter.ToUpper()) orderby d.FullName, d.IsActive select d).ToList();
            return data;
        }

    }
}
