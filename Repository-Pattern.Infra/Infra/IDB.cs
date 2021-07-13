using System.Data;

namespace Repository_Pattern.Infra.Infra
{
    public interface IDB
    {
        IDbConnection GetConnection();
    }
}
