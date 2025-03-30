using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public partial class CrearNewDB : Form
    {
        public string NombreBaseDatos { get; private set; }

        public CrearNewDB()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreBD.Text))
                {
                    MessageBox.Show("El nombre de la base de datos no puede estar vacío.");
                    return;
                }

                // Se obtiene la conexión actual
                var dbConnection = ConexionManager.Conexion;
                // Ejecutar la creación de la base de datos con el nombre proporcionado
                dbConnection.CreateDatabase(txtNombreBD.Text.Trim());

                MessageBox.Show("Base de datos creada exitosamente.");
                NombreBaseDatos = txtNombreBD.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL al crear la base de datos: " + ex.Message);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL al crear la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
            }
        }
    }
}