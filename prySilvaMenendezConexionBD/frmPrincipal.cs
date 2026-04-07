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
    public partial class frmPrincipal : Form
    {
        private ClassConexionBD objConectarBD = new ClassConexionBD();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                objConectarBD.ConectarBD();
                MessageBox.Show(objConectarBD.conn != null && objConectarBD.conn.State == ConnectionState.Open
                ? "Conexión abierta"
                : "Conexión NO abierta");
                lblEstadoConexion.Text = "Base Conectada";
                lblEstadoConexion.BackColor = Color.Green;

                CargarDatos();
            }
            catch (Exception ex)
            {
                lblEstadoConexion.Text = "Sin Conexión";
                lblEstadoConexion.BackColor = Color.Red;
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarDatos()
        {
            try
            {
                string sql = "SELECT * FROM Personaje";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, objConectarBD.conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros en la tabla Personaje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dgvDatos.Columns.Clear();
                    dgvDatos.AutoGenerateColumns = true;
                    dgvDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
