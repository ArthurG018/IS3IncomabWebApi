using Dapper;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.StaticClass.Structure;
using IS3IncomabWebApi.Infraestructure.Interface;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public ReportRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public IEnumerable<Report01> GetReport01()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportUbicationCylinderR01";
            var result = db.Query<Report01>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Report02> GetReport02()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportRecorridoCilindroR02";
            var result = db.Query<Report02>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Report03> GetReport03()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportCilindroGarantiaR03";
            var result = db.Query<Report03>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Report04> GetReport04()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportClienteHistorialCilindroR04";
            var result = db.Query<Report04>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Report05> GetReport05(int customerId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportPorClienteHistorialCilindroR05";
            var parameters = new DynamicParameters();
            parameters.Add("customerId", customerId);
            var result = db.Query<Report05>(query, commandType: CommandType.StoredProcedure, param:parameters);
            return result;
        }

        public IEnumerable<Report06> GetReport06()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportVentaMesR06";
            var result = db.Query<Report06>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Report07> GetReport07()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportVentaTipoCilindroR07";
            var result = db.Query<Report07>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Report08> GetReport08()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportM3ClienteMensualR08";
            var result = db.Query<Report08>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public ReportDashboard GetReportDashboard()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_reportDashboard";
            var result = db.QuerySingle<ReportDashboard>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
