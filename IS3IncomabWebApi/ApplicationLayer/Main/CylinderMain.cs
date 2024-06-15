using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using Microsoft.IdentityModel.Tokens;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class CylinderMain : ICylinderDto
    {
        private readonly ICylinderDomain _cylinderDomain;
        private readonly IMapper _mapper;

        public CylinderMain(ICylinderDomain cylinderDomain, IMapper mapper)
        {
            _cylinderDomain = cylinderDomain;
            _mapper = mapper;
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
        public Response<bool> Update(CylinderDto cylinderDto)
        {
            var response = new Response<bool>();
            try
            {
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
                var cylinder = _cylinderDomain.Get(cylinderId);
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
            data = (from d in data where d.Number.Contains(filter.ToUpper())  orderby d.Number, d.IsActive select d).ToList();
            return data;
        }


        
    }
}
