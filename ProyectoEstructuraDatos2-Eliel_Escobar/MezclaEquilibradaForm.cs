using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoEstructuraDatos2_Eliel_Escobar
{
    public partial class MezclaEquilibradaForm : Form
    {
        public MezclaEquilibradaForm()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        public string rutaArchivo;
        int cantidad;
        int nombreArchivo;
        int i = 0;
        int[] datos;

        MezclaEquilibrada mezclaEquilibrada = new MezclaEquilibrada();
        OpenFileDialog file = new OpenFileDialog();

        public void cargarArchivoTexto()
        {
            file.ShowDialog();

            if (!string.IsNullOrEmpty(file.FileName))
            {
                rutaArchivo = file.FileName;
                mezclaEquilibrada.LeerArchivo(dataGridView1, rutaArchivo);
            }
            else
            {
                MessageBox.Show("No se encontraron elementos validos en el archivo o esta vacio.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            cargarArchivoTexto();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            mezclaEquilibrada.CrearArchivoTexto();
            groupBox1.Enabled = true;
            txtCantidad.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
                datos = new int[cantidad];
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ingrese la cantidad de elementos.", "Aviso");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtElementos.Text != "")
            {
                datos[i] = Convert.ToInt32(txtElementos.Text);
                txtElementos.Clear();
                i++;

                if (i == cantidad)
                {
                    mezclaEquilibrada.MostrarData(dataGridView1, datos);
                }
            }
            else
            {
                MessageBox.Show("el campo no puede estar vacio.", "Aviso");
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            cantidad = 0;
            dataGridView1.Rows.Clear();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }
    }
}
