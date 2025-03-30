using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public partial class ConexionForm : Form
    {
        public ConexionForm()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServidor.Text) ||
                    string.IsNullOrWhiteSpace(txtBaseDatos.Text) ||
                    string.IsNullOrWhiteSpace(txtUsuarioId.Text))
                {
                    MessageBox.Show("Complete todos los campos obligatorios.");
                    return;
                }

                // Seleccionar conexión según el radio button
                DBConnection dbConnection;
                if (radSQLServer.Checked)
                {
                    dbConnection = new SQLConnection(txtServidor.Text.Trim(), txtBaseDatos.Text.Trim(), txtUsuarioId.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    dbConnection = new MySQLConnection(txtServidor.Text.Trim(), txtBaseDatos.Text.Trim(), txtUsuarioId.Text.Trim(), txtPassword.Text.Trim());
                }

                // Probar la conexión
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                }

                // Guardar la conexión para toda la aplicación
                ConexionManager.Conexion = dbConnection;

                MessageBox.Show("Conexión establecida exitosamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL: " + ex.Message);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
            }
        }
    }
}
