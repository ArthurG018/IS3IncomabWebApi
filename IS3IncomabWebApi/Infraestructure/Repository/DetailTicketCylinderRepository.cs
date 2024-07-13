using Dapper;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Repository
{
    public class DetailTicketCylinderRepository : IDetailTicketCylinderRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public DetailTicketCylinderRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public bool Insert(DetailTicketCylinder detailTicketCylinder)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_detailTicketCylinderInsert";
            var parameters = new DynamicParameters();
            parameters.Add("isWarranty", detailTicketCylinder.IsWarranty);
            parameters.Add("isReturned", detailTicketCylinder.IsReturned);
            parameters.Add("amount", detailTicketCylinder.Amount);
            parameters.Add("cilynderId", detailTicketCylinder.CylinderId);
            parameters.Add("ticketId", detailTicketCylinder.TicketId);

            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;

        }

        public bool Update(DetailTicketCylinder detailTicketCylinder)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", detailTicketCylinder.TicketId);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Delete(int detailTicketCylinderId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", detailTicketCylinderId);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public DetailTicketCylinder Get(int detailTicketCylinderId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", detailTicketCylinderId);
            var result = db.QuerySingle<DetailTicketCylinder>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<DetailTicketCylinder> GetAll()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var result = db.Query<DetailTicketCylinder>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
