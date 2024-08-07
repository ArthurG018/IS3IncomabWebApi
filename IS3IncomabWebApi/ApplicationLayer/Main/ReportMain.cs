using IS3IncomabWebApi.ApplicationLayer.Interface;
using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.StaticClass.Structure;
using IS3IncomabWebApi.Infraestructure.Interface;

namespace IS3IncomabWebApi.ApplicationLayer.Main
{
    public class ReportMain : IReportMain
    {
        private readonly IReportRepository _reportRepository;

        public ReportMain(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public Response<IEnumerable<Report01>> GetReport01()
        {
            var response = new Response<IEnumerable<Report01>>();
            try
            {
                var report = _reportRepository.GetReport01();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report02>> GetReport02()
        {
            var response = new Response<IEnumerable<Report02>>();
            try
            {
                var report = _reportRepository.GetReport02();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report03>> GetReport03()
        {
            var response = new Response<IEnumerable<Report03>>();
            try
            {
                var report = _reportRepository.GetReport03();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report04>> GetReport04()
        {
            var response = new Response<IEnumerable<Report04>>();
            try
            {
                var report = _reportRepository.GetReport04();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report05>> GetReport05(int customerId)
        {
            var response = new Response<IEnumerable<Report05>>();
            try
            {
                var report = _reportRepository.GetReport05(customerId);
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report06>> GetReport06()
        {
            var response = new Response<IEnumerable<Report06>>();
            try
            {
                var report = _reportRepository.GetReport06();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report07>> GetReport07()
        {
            var response = new Response<IEnumerable<Report07>>();
            try
            {
                var report = _reportRepository.GetReport07();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<IEnumerable<Report08>> GetReport08()
        {
            var response = new Response<IEnumerable<Report08>>();
            try
            {
                var report = _reportRepository.GetReport08();
                response.Data = report;
                if (response.Data != null)
                {
                    response.Message = "Consulta exitosa";
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Consulta no Exitosa " + e.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
