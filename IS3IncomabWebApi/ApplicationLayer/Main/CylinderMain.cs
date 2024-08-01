using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class CylinderMain : ICylinderDto
    {
        private readonly ICylinderDomain _cylinderDomain;
        private readonly IMapper _mapper;
        private readonly IUserIncomabDomain _userIncomabDomain;

        public CylinderMain(ICylinderDomain cylinderDomain, IMapper mapper, IUserIncomabDomain userIncomabDomain)
        {
            _cylinderDomain = cylinderDomain;
            _mapper = mapper;
            _userIncomabDomain = userIncomabDomain;
        }

        public Response<IEnumerable<CylinderDto>> GetAll(int StartIndex, int MaxRecord, string filter)
        {
            var response = new Response<IEnumerable<CylinderDto>>();
            try
            {
                var cylinders = _cylinderDomain.GetAll();
                var cylindersFilter = FilterCylinder(_mapper.Map<List<CylinderDto>>(cylinders), filter);
                response = PageCylinder(StartIndex, MaxRecord, cylindersFilter);
                if (response.Data != null)
                {
                    response.Data = MapNameUsers(response.Data);
                }
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
        public Response<bool> Update(CylinderDto cylinderDto)
        {
            var response = new Response<bool>();
            try
            {
                if (ValidNumberCylinder(cylinderDto.Number))
                {
                    response.IsSuccess = false;
                    response.Message = "El número de Cilindro no Existe";
                }
                response.Data = _cylinderDomain.Update(_mapper.Map<Cylinder>(cylinderDto));
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

        public Response<bool> DeleteLogic(int cylinderId, int userId)
        {
            var response = new Response<bool>();
            try
            {
                var cylinder = _cylinderDomain.GetId(cylinderId);
                cylinder.IsActive = (cylinder.IsActive == 1) ? 0 : 1;
                cylinder.ModifyBy = userId;
                response.Data = _cylinderDomain.DeleteLogic(cylinder);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = (cylinder.IsActive == 1) ? "Activado" : "Desactivado";
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<CylinderDto> GetId(int cylinderId)
        {
            var response = new Response<CylinderDto>();
            try
            {
                var cylinder = _cylinderDomain.GetId(cylinderId);
                response.Data = _mapper.Map<CylinderDto>(cylinder);
                if (response.Data != null)
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
        public Response<int> Insert(CylinderDto cylinderDto)
        {
            var response = new Response<int>();
            try
            {
                if (!ValidNumberCylinder(cylinderDto.Number))
                {
                    response.IsSuccess = false;
                    response.Message = "Este número de cilindro ya existe";

                }
                else
                {
                    var cylinder = _mapper.Map<Cylinder>(cylinderDto);
                    response.Data = _cylinderDomain.Insert(cylinder);
                    if (response.Data > 0)
                    {
                        response.IsSuccess = true;
                        response.Message = "Consulta Exitosa";
                    }
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
        public Response<IEnumerable<CylinderDto>> PageCylinder(int StartIndex, int MaxRecord, List<CylinderDto> data)
        {
            var response = new Response<IEnumerable<CylinderDto>>();
            if (data.IsNullOrEmpty()) return response;
            response.Count = data.Count;
            response.Data = data;
            if (MaxRecord.Equals(0)) return response;
            response.Data = data.Skip(StartIndex).Take(MaxRecord);

            return response;
        }

        /*Function for Filter*/
        public List<CylinderDto> FilterCylinder(List<CylinderDto> data, string filter)
        {
            if (filter.IsNullOrEmpty()) return data;
            data = (from d in data where d.Number.ToUpper().Contains(filter.ToUpper()) orderby d.Number, d.IsActive select d).ToList();
            return data;
        }

        /*map users*/
        public IEnumerable<CylinderDto> MapNameUsers(IEnumerable<CylinderDto> data)
        {
            var usres = _userIncomabDomain.GetAll();
            foreach (var item in data)
            {
                foreach (var item1 in usres)
                {
                    if (item.CreateBy == item1.Id)
                    {
                        item.NameCreate = item1.Name;
                    }
                    if (item.ModifyBy == item1.Id)
                    {
                        item.NameModify = item1.Name;
                    }
                }
            }
            return data;
        }

        public bool ValidNumberCylinder(string num)
        {
            var cylinders = _cylinderDomain.GetAll();
            var filter = cylinders.Where(predicate: c => c.Number.ToUpper().Equals(num.ToUpper())).ToList();
            return filter.Count() == 0;
        }

       
    }
}
