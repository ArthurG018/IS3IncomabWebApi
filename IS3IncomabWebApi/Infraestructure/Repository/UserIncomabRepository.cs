using Dapper;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Repository
{
    public class UserIncomabRepository :IUserIncomabRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public UserIncomabRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public bool Insert(UserIncomab userIncomab)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", userIncomab.Name);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;

        }

        public bool Update(UserIncomab userIncomab)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", userIncomab.Name);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Delete(int userIncomabId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", userIncomabId);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public UserIncomab Get(int userIncomabId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", userIncomabId);
            var result = db.QuerySingle<UserIncomab>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<UserIncomab> GetAll()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var result = db.Query<UserIncomab>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
