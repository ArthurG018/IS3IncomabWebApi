using IS3IncomabWebApi.CrossLayer.Common;
using IS3IncomabWebApi.DomainLayer.StaticClass.Structure;

namespace IS3IncomabWebApi.ApplicationLayer.Interface
{
    public interface IReportMain
    {
        Response<IEnumerable<Report01>> GetReport01();
        Response<IEnumerable<Report02>> GetReport02();
        Response<IEnumerable<Report03>> GetReport03();
        Response<IEnumerable<Report04>> GetReport04();
        Response<IEnumerable<Report05>> GetReport05(int customerId);
        Response<IEnumerable<Report06>> GetReport06(); 
        Response<IEnumerable<Report07>> GetReport07();
        Response<IEnumerable<Report08>> GetReport08();
    }
}
