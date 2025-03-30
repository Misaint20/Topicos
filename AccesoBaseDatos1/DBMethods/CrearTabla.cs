using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public partial class CrearTabla: Form
    {
        public CrearTabla()
        {
            InitializeComponent();
        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreTabla.Text))
                {
                    MessageBox.Show("El nombre de la tabla no puede estar vacío.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDefinicionColumnas.Text))
                {
                    MessageBox.Show("La definición de columnas no puede estar vacía.");
                    return;
                }

                // Se obtiene la conexión actual
                var dbConnection = ConexionManager.Conexion;
                // Ejecutar la creación de la tabla con la definición proporcionada
                dbConnection.CreateTable(txtNombreTabla.Text.Trim(), txtDefinicionColumnas.Text.Trim());

                MessageBox.Show("Tabla creada exitosamente.");

                // Preguntar si desea crear otra tabla
                DialogResult resultado = MessageBox.Show("¿Desea crear otra tabla?", "Crear Tabla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    // Limpiar campos para permitir crear otra tabla
                    txtNombreTabla.Clear();
                    txtDefinicionColumnas.Clear();
                    txtNombreTabla.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL al crear la tabla: " + ex.Message);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL al crear la tabla: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
            }
        }
    }
}
