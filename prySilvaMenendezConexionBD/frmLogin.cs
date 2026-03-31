using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySilvaMenendezConexionBD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string email = mskGmail.Text?.Trim();
            string password = mskContrseña.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese email y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var objConectarBD = new ClassConexionBD();

            try
            {
                objConectarBD.ConectarBD();

                
                DataTable tablas = objConectarBD.conn.GetSchema("Tables");
                string foundTable = null;
                string emailColumn = null;
                string passwordColumn = null;

               
                string[] posiblesEmail = { "Gmail", "Email", "Mail", "Usuario", "User" };
                string[] posiblesPassword = { "Contraseña", "Contrasena", "Password", "Pwd" };

               
                foreach (DataRow row in tablas.Rows)
                {
                    string tableName = row["TABLE_NAME"]?.ToString();
                    string tableType = row["TABLE_TYPE"]?.ToString();
                    if (!string.Equals(tableType, "TABLE", StringComparison.OrdinalIgnoreCase))
                        continue;

                    DataTable columnas = objConectarBD.conn.GetSchema("Columns", new string[] { null, null, tableName, null });
                    var columnNames = columnas.AsEnumerable().Select(r => r["COLUMN_NAME"].ToString()).ToList();

                    var foundEmail = columnNames.FirstOrDefault(c => posiblesEmail.Contains(c, StringComparer.OrdinalIgnoreCase));
                    var foundPass = columnNames.FirstOrDefault(c => posiblesPassword.Contains(c, StringComparer.OrdinalIgnoreCase));

                    if (foundEmail != null && foundPass != null)
                    {
                        foundTable = tableName;
                        emailColumn = foundEmail;
                        passwordColumn = foundPass;
                        break;
                    }
                }

                if (foundTable == null)
                {
                    MessageBox.Show("No se encontró una tabla de usuarios con columnas de email/contraseña en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                string sqlEmailCount = $"SELECT COUNT(*) FROM [{foundTable}] WHERE [{emailColumn}] = ?";
                using (var cmdCount = new OleDbCommand(sqlEmailCount, objConectarBD.conn))
                {
                    cmdCount.Parameters.AddWithValue("?", email);
                    int count = Convert.ToInt32(cmdCount.ExecuteScalar());
                    if (count == 0)
                    {
                        MessageBox.Show("Email no registrado.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                
                string sqlGetPass = $"SELECT [{passwordColumn}] FROM [{foundTable}] WHERE [{emailColumn}] = ?";
                using (var cmdPass = new OleDbCommand(sqlGetPass, objConectarBD.conn))
                {
                    cmdPass.Parameters.AddWithValue("?", email);
                    object dbPassObj = cmdPass.ExecuteScalar();
                    string dbPass = dbPassObj?.ToString() ?? string.Empty;

                    if (!string.Equals(dbPass, password, StringComparison.Ordinal))
                    {
                        MessageBox.Show("Contraseña incorrecta.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                
                var principal = new frmPrincipal();
                principal.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                try
                {
                    if (objConectarBD?.conn != null && objConectarBD.conn.State != ConnectionState.Closed)
                        objConectarBD.conn.Close();
                }
                catch { /* Ignorar errores de cierre */ }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }
    }
}
