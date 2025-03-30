using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public static class Helpers
    {
        public static IEnumerable<string> GetColumnNames(Panel panelControles)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is TextBox txt)
                {
                    yield return txt.Name.Substring(3); // Eliminar el prefijo "txt"
                }
            }
        }

        public static IEnumerable<string> GetParameterNames(Panel panelControles)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is TextBox txt)
                {
                    yield return "@" + txt.Name.Substring(3); // Eliminar el prefijo "txt"
                }
            }
        }

        public static IEnumerable<IDbDataParameter> GetParameters(Panel panelControles, DBConnection dbConnection)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is TextBox txt)
                {
                    var param = dbConnection.CreateParameter();
                    param.ParameterName = "@" + txt.Name.Substring(3); // Eliminar el prefijo "txt"
                    param.Value = txt.Text;
                    yield return param;
                }
            }
        }

        public static IEnumerable<string> GetUpdateSetClauses(Panel panelControles)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is TextBox txt)
                {
                    yield return $"{txt.Name.Substring(3)} = @{txt.Name.Substring(3)}"; // Eliminar el prefijo "txt"
                }
            }
        }

        public static string GetPrimaryKeyClause(DataGridView dgvAlumnos)
        {
            // Suponiendo que la clave primaria es la primera columna
            var primaryKeyColumn = dgvAlumnos.Columns[0].Name;
            return $"{primaryKeyColumn} = @{primaryKeyColumn}";
        }

        public static string GetSearchClause(DataGridView dgvAlumnos)
        {
            // Suponiendo que la búsqueda se realiza por la primera columna
            var searchColumn = dgvAlumnos.Columns[0].Name;
            return $"{searchColumn} = @{searchColumn}";
        }
    }
}
