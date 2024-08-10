using IS3IncomabWebApi.DomainLayer.StaticClass.Structure;

namespace IS3IncomabWebApi.Infraestructure.Interface
{
    public interface IReportRepository
    {
        IEnumerable<Report01> GetReport01();
        IEnumerable<Report02> GetReport02();
        IEnumerable<Report03> GetReport03();
        IEnumerable<Report04> GetReport04();
        IEnumerable<Report05> GetReport05(int customerId);
        IEnumerable<Report06> GetReport06();
        IEnumerable<Report07> GetReport07();
        IEnumerable<Report08> GetReport08();
        ReportDashboard GetReportDashboard();
    }
}
