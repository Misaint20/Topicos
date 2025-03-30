using System.Data;
using System.Data.SqlClient;

namespace AccesoBaseDatos1
{
    public class SQLConnection : DBConnection
    {
        public SQLConnection(string servidor, string basedatos, string usuarioId, string password)
            : base(servidor, basedatos, usuarioId, password, true)
        {
        }

        public override IDbConnection GetConnection()
        {
            return new SqlConnection($"Server={Servidor};Database={BaseDatos};User Id={UsuarioId};Password={Password};");
        }
    }
}
