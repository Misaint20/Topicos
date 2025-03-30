using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public abstract class DBConnection
    {
        public string Servidor { get; }
        public string BaseDatos { get; }
        public string UsuarioId { get; }
        public string Password { get; }
        public bool EsSQLServer { get; }

        protected DBConnection(string servidor, string basedatos, string usuarioId, string password, bool esSQLServer)
        {
            Servidor = servidor;
            BaseDatos = basedatos;
            UsuarioId = usuarioId;
            Password = password;
            EsSQLServer = esSQLServer;
        }

        public abstract IDbConnection GetConnection();

        public IDbDataParameter CreateParameter()
        {
            if (EsSQLServer)
            {
                return new SqlParameter();
            }
            else
            {
                return new MySqlParameter();
            }
        }

        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            return command;
        }

        public void CreateDatabase(string databaseName)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    if (EsSQLServer)
                    {
                        cmd.CommandText = $"CREATE DATABASE {databaseName}";
                    }
                    else
                    {
                        cmd.CommandText = $"CREATE DATABASE `{databaseName}`";
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateTable(string tableName, string columnDefinitions)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"CREATE TABLE {tableName} ({columnDefinitions})";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
