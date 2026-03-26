using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySilvaMenendezConexionBD
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ClassConexionBD objConectarBD = new ClassConexionBD();

            try
            {
                objConectarBD.ConectarBD();
                lblEstadoConexion1.Text = "Base Conectada";
                lblEstadoConexion1.BackColor = Color.Green;
            }
            catch (Exception)
            {
                lblEstadoConexion.Text = "Sin Conexión";
                lblEstadoConexion.BackColor = Color.Red;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
