using IS3IncomabWebApi.CrossLayer.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Data
{
    public class ConnectionDataBase: IConnectionDataBase
    {
        private readonly IConfiguration _configuration;

        public ConnectionDataBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection {get
            {
                #pragma warning disable IDE0017
                SqlConnection sqlConnection = new();
                sqlConnection.ConnectionString = _configuration.GetConnectionString("ConnectionDB");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
