using System.Data;

namespace IS3IncomabWebApi.CrossLayer.Interface
{
    public interface IConnectionDataBase
    {
        public IDbConnection GetConnection { get; }
    }
}
