using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public class MySQLConnection : DBConnection
    {
        public MySQLConnection(string servidor, string basedatos, string usuarioId, string password)
            : base(servidor, basedatos, usuarioId, password, false)
        {
        }

        public override IDbConnection GetConnection()
        {
            return new MySqlConnection($"Server={Servidor};Database={BaseDatos};User Id={UsuarioId};Password={Password};Port=3306;");
        }
    }
}
