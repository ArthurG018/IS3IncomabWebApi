﻿using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Core;
using IS3IncomabWebApi.DomainLayer.Entity;
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
                response = PageCustomer(StartIndex, MaxRecord, customersFilter);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa";
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<bool> Update(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Update(_mapper.Map<Customer>(customerDto));
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<bool> DeleteLogic(int customerId, int userId)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _customerDomain.Get(customerId);
                customer.IsActive = (customer.IsActive == 1) ? 0 : 1;
                customer.ModifyBy = userId;
                response.Data = _customerDomain.DeleteLogic(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = (customer.IsActive == 1) ? "Activado" : "Desactivado";
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        /*Function for pagination*/
        public Response<IEnumerable<CustomerDto>> PageCustomer(int StartIndex, int MaxRecord, List<CustomerDto> data )
        {
            var response = new Response<IEnumerable<CustomerDto>> ();
            if (data.IsNullOrEmpty()) return response;
            response.Count = data.Count;
            response.Data = data;
            if(MaxRecord.Equals(0)) return response;
           response.Data = data.Skip(StartIndex).Take(MaxRecord);
            
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
