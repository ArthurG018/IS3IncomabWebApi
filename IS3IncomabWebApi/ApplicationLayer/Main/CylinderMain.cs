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
                response.Data = PageCylinder(StartIndex, MaxRecord, cylindersFilter);

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
        public IEnumerable<CylinderDto> PageCylinder(int StartIndex, int MaxRecord, List<CylinderDto> data)
        {
            if (data.IsNullOrEmpty()) return data;
            data[0].TotalRecords = data.Count;
            if (MaxRecord.Equals(0)) return data;
            var response = data.Skip(StartIndex).Take(MaxRecord);

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
