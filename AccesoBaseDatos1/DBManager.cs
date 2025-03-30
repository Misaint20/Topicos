using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public partial class DBManager : Form
    {
        public DBManager()
        {
            InitializeComponent();
            dgvAlumnos.CellDoubleClick += dgvAlumnos_CellDoubleClick;
            cmbTablas.SelectedIndexChanged += cmbTablas_SelectedIndexChanged;
            radSQLServer.CheckedChanged += radSQLServer_CheckedChanged;
            radMySQL.CheckedChanged += radMySQL_CheckedChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Verificar que ya se haya establecido la conexión
            if (ConexionManager.Conexion == null)
            {
                MessageBox.Show("No se ha establecido la conexión a la base de datos.");
                Application.Exit();
            }
            else
            {
                radSQLServer.Checked = ConexionManager.Conexion.EsSQLServer;
                radMySQL.Checked = !ConexionManager.Conexion.EsSQLServer;
            }

            // Llenar el ComboBox con las tablas de la base de datos
            CargarComboTablas();
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = "";
            if (cmbTablas.SelectedValue is DataRowView drv)
            {
                tableName = drv["TableName"].ToString();
            }
            else
            {
                tableName = cmbTablas.SelectedValue.ToString();
            }

            if (tableName != "Seleccionar...")
            {
                CargarTablaData(tableName);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarComboTablas();

            if (dgvAlumnos.Columns.Count > 0)
            {
                // Verificar si la columna actual se llama "TableName"
                if (dgvAlumnos.Columns[0].Name == "TableName" ||
                    dgvAlumnos.Columns[0].HeaderText.StartsWith("Tables"))
                {
                    CargarComboTablas();
                }
                else
                {
                    // Se obtiene el nombre de la tabla a través del Tag
                    string currentTable = dgvAlumnos.Tag as string;
                    if (!string.IsNullOrEmpty(currentTable))
                    {
                        CargarTablaData(currentTable);
                    }
                }
            }
        }

        private void btnCrearDB_Click(object sender, EventArgs e)
        {
            CrearNewDB crearDBForm = new CrearNewDB();
            if (crearDBForm.ShowDialog() == DialogResult.OK)
            {
                // Actualizar la conexión para usar la nueva base de datos
                string nuevaBaseDatos = crearDBForm.NombreBaseDatos;
                DBConnection dbConnection = ConexionManager.Conexion;
                if (dbConnection.EsSQLServer)
                {
                    ConexionManager.Conexion = new SQLConnection(dbConnection.Servidor, nuevaBaseDatos, dbConnection.UsuarioId, dbConnection.Password);
                }
                else
                {
                    ConexionManager.Conexion = new MySQLConnection(dbConnection.Servidor, nuevaBaseDatos, dbConnection.UsuarioId, dbConnection.Password);
                }

                // Recargar las tablas
                CargarComboTablas();
            }
        }

        private void CargarTablaData(string tableName)
        {
            try
            {
                DBConnection dbConnection = ConexionManager.Conexion;
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = $"SELECT * FROM {tableName}";
                    using (IDbCommand cmd = dbConnection.CreateCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        dgvAlumnos.DataSource = dt;
                        // Guardar el nombre de la tabla que se está visualizando en el Tag
                        dgvAlumnos.Tag = tableName;

                        // Obtener el esquema de la tabla
                        DataTable schemaTable = null;
                        if (conn is SqlConnection sqlConn)
                        {
                            schemaTable = sqlConn.GetSchema("Columns", new string[] { null, null, tableName, null });
                        }
                        else if (conn is MySqlConnection mySqlConn)
                        {
                            schemaTable = mySqlConn.GetSchema("Columns", new string[] { null, null, tableName, null });
                        }

                        if (schemaTable != null)
                        {
                            CargarControlesDinamicos(schemaTable, dbConnection.EsSQLServer);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL al cargar la tabla '" + tableName + "': " + ex.Message);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL al cargar la tabla '" + tableName + "': " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla '" + tableName + "': " + ex.Message);
            }
        }

        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tableName = dgvAlumnos.Rows[e.RowIndex].Cells["TableName"].Value.ToString();
                CargarTablaData(tableName);
            }
        }

        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
            CrearTabla crearTablaForm = new CrearTabla();
            crearTablaForm.ShowDialog();
        }

        private void CargarComboTablas()
        {
            try
            {
                // Se utiliza la conexión establecida previamente
                DBConnection dbConnection = ConexionManager.Conexion;
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "";
                    if (dbConnection.EsSQLServer)
                    {
                        query = "SELECT name AS TableName FROM sys.Tables ORDER BY name";
                    }
                    else
                    {
                        query = "SHOW TABLES";
                    }
                    using (IDbCommand cmd = dbConnection.CreateCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        // Para MySQL, renombrar la primera columna a "TableName" para uniformidad
                        if (!dbConnection.EsSQLServer && dt.Columns.Count > 0)
                        {
                            dt.Columns[0].ColumnName = "TableName";
                        }
                        // Crear una fila para la opción predeterminada "Seleccionar"
                        DataRow dr = dt.NewRow();
                        dr["TableName"] = "Seleccionar...";
                        dt.Rows.InsertAt(dr, 0);
                        // Asignar el DataTable al ComboBox
                        cmbTablas.DataSource = dt;
                        cmbTablas.DisplayMember = "TableName";
                        cmbTablas.ValueMember = "TableName";
                        cmbTablas.SelectedIndex = 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL al cargar las tablas: " + ex.Message);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL al cargar las tablas: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las tablas: " + ex.Message);
            }
        }

        private void CargarControlesDinamicos(DataTable schemaTable, bool esSQLServer)
        {
            // Limpiar controles existentes
            panelControles.Controls.Clear();

            int yPos = 10; // Posición vertical inicial
            int xPos = 10; // Posición horizontal inicial
            int maxLabelWidth = 0; // Ancho máximo de los labels
            int controlSpacing = 10; // Espacio entre controles

            // Calcular el ancho máximo de los labels
            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = esSQLServer ? row["COLUMN_NAME"].ToString() : row["COLUMN_NAME"].ToString();
                Label lbl = new Label();
                lbl.Text = columnName;
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(xPos, yPos);
                panelControles.Controls.Add(lbl);
                maxLabelWidth = Math.Max(maxLabelWidth, lbl.Width);
            }

            // Limpiar controles nuevamente para agregar los definitivos
            panelControles.Controls.Clear();

            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = esSQLServer ? row["COLUMN_NAME"].ToString() : row["COLUMN_NAME"].ToString();

                // Crear y configurar Label
                Label lbl = new Label();
                lbl.Text = columnName;
                lbl.Location = new System.Drawing.Point(xPos, yPos);
                lbl.AutoSize = true;
                panelControles.Controls.Add(lbl);

                // Crear y configurar TextBox
                TextBox txt = new TextBox();
                txt.Name = "txt" + columnName;
                txt.Location = new System.Drawing.Point(xPos + maxLabelWidth + controlSpacing, yPos);
                txt.Width = panelControles.Width - (xPos + maxLabelWidth + controlSpacing + controlSpacing);
                panelControles.Controls.Add(txt);

                yPos += txt.Height + controlSpacing;
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = dgvAlumnos.Tag as string;
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Seleccione una tabla primero.");
                    return;
                }

                DBConnection dbConnection = ConexionManager.Conexion;
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand($"INSERT INTO {tableName} ({string.Join(", ", Helpers.GetColumnNames(panelControles))}) VALUES ({string.Join(", ", Helpers.GetParameterNames(panelControles))})", conn))
                    {
                        foreach (var param in Helpers.GetParameters(panelControles, dbConnection))
                        {
                            cmd.Parameters.Add(param);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Registro insertado correctamente.");
                CargarTablaData(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el registro: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = dgvAlumnos.Tag as string;
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Seleccione una tabla primero.");
                    return;
                }

                DBConnection dbConnection = ConexionManager.Conexion;
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand($"UPDATE {tableName} SET {string.Join(", ", Helpers.GetUpdateSetClauses(panelControles))} WHERE {Helpers.GetPrimaryKeyClause(dgvAlumnos)}", conn))
                    {
                        foreach (var param in Helpers.GetParameters(panelControles, dbConnection))
                        {
                            cmd.Parameters.Add(param);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Registro actualizado correctamente.");
                CargarTablaData(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = dgvAlumnos.Tag as string;
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Seleccione una tabla primero.");
                    return;
                }

                DBConnection dbConnection = ConexionManager.Conexion;
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand($"SELECT * FROM {tableName} WHERE {Helpers.GetSearchClause(dgvAlumnos)}", conn))
                    {
                        foreach (var param in Helpers.GetParameters(panelControles, dbConnection))
                        {
                            cmd.Parameters.Add(param);
                        }
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        dgvAlumnos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el registro: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = dgvAlumnos.Tag as string;
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show("Seleccione una tabla primero.");
                    return;
                }

                DBConnection dbConnection = ConexionManager.Conexion;
                using (IDbConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = dbConnection.CreateCommand($"DELETE FROM {tableName} WHERE {Helpers.GetPrimaryKeyClause(dgvAlumnos)}", conn))
                    {
                        foreach (var param in Helpers.GetParameters(panelControles, dbConnection))
                        {
                            cmd.Parameters.Add(param);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Registro borrado correctamente.");
                CargarTablaData(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el registro: " + ex.Message);
            }
        }
        private void radSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            if (radSQLServer.Checked && ConexionManager.Conexion != null && !ConexionManager.Conexion.EsSQLServer)
            {
                SolicitarNuevaConexion();
            }
        }

        private void radMySQL_CheckedChanged(object sender, EventArgs e)
        {
            if (radMySQL.Checked && ConexionManager.Conexion != null && ConexionManager.Conexion.EsSQLServer)
            {
                SolicitarNuevaConexion();
            }
        }

        private void SolicitarNuevaConexion()
        {
            DialogResult result = MessageBox.Show("Debe iniciar sesión nuevamente para cambiar el motor de base de datos. ¿Desea continuar?", "Cambiar Motor de Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ConexionForm conexionForm = new ConexionForm();
                if (conexionForm.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar la selección de los RadioButton según la nueva conexión
                    radSQLServer.Checked = ConexionManager.Conexion.EsSQLServer;
                    radMySQL.Checked = !ConexionManager.Conexion.EsSQLServer;
                    // Recargar las tablas
                    CargarComboTablas();
                }
                else
                {
                    // Revertir la selección de los RadioButton si el usuario cancela la nueva conexión
                    radSQLServer.CheckedChanged -= radSQLServer_CheckedChanged;
                    radMySQL.CheckedChanged -= radMySQL_CheckedChanged;
                    radSQLServer.Checked = !radSQLServer.Checked;
                    radMySQL.Checked = !radMySQL.Checked;
                    radSQLServer.CheckedChanged += radSQLServer_CheckedChanged;
                    radMySQL.CheckedChanged += radMySQL_CheckedChanged;
                }
            }
            else
            {
                // Revertir la selección de los RadioButton si el usuario cancela la nueva conexión
                radSQLServer.CheckedChanged -= radSQLServer_CheckedChanged;
                radMySQL.CheckedChanged -= radMySQL_CheckedChanged;
                radSQLServer.Checked = !radSQLServer.Checked;
                radMySQL.Checked = !radMySQL.Checked;
                radSQLServer.CheckedChanged += radSQLServer_CheckedChanged;
                radMySQL.CheckedChanged += radMySQL_CheckedChanged;
            }
        }
    }
}
