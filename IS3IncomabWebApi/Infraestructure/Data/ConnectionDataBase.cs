using IS3IncomabWebApi.CrossLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
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
                sqlConnection.ConnectionString = (sqlConnection.WorkstationId.Equals(_configuration.GetConnectionString("DesktopArthur"))) ? _configuration.GetConnectionString("ConnectionDB") : _configuration.GetConnectionString("ConnectionF");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
