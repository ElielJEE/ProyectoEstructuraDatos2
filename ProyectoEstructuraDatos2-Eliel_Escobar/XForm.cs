using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuraDatos2_Eliel_Escobar
{
    public partial class XForm : Form
    {
        public XForm()
        {
            InitializeComponent();
        }

        public int nota;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNota.Text != "")
            {
                nota = Convert.ToInt32(txtNota.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese el numero de carnet del estudiante.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
