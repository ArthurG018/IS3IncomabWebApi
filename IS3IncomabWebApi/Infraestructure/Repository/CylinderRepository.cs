using Dapper;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using IS3IncomabWebApi.Modules.MappingDescription;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Repository
{
    public class CylinderRepository : ICylinderRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public CylinderRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public bool Insert(Cylinder cylinder)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", cylinder.Number);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
            
        }

        public bool Update(Cylinder cylinder)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", cylinder.Number);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Delete(int cylinderId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", cylinderId);
            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public Cylinder Get(int cylinderId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("", cylinderId);
            var result = db.QuerySingle<Cylinder>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Cylinder> GetAll()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_cylinderGetAll";
            MappingForDescription.MapCylinder();
            var result = db.Query<Cylinder>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
