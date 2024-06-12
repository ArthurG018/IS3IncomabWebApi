using Dapper;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public TicketRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public bool Insert(Ticket ticket)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", ticket.IsOmitted);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;

        }

        public bool Update(Ticket ticket)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", ticket.IsOmitted);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Delete(int ticketId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", ticketId);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public Ticket Get(int ticketId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", ticketId);
            var result = db.QuerySingle<Ticket>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Ticket> GetAll()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var result = db.Query<Ticket>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
