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
    public partial class ArbolBalanceadoForm : Form
    {
        CArbolBalanceado arbolBalanceado;
        Graphics nodo;
        public ArbolBalanceadoForm()
        {
            InitializeComponent();
            nodo = CreateGraphics();
            arbolBalanceado = new CArbolBalanceado(nodo, Font);
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }

        int cantidad = 0, i = 0, k;

        public struct Estudiantes
        {
            public double notaFinal;
            public string nombre;
        }
        Estudiantes[] estudiante;

        #region Bonton para aceptar la cantidad
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && txtCantidad.Text != "0")
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
                estudiante = new Estudiantes[cantidad];

                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox4.Enabled = true;

                k = cantidad;
            }
            else
            {
                MessageBox.Show("Agregue una cantidad valida de estudiantes.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Boton para ingresar datos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double nota1, nota2, nota3;
            if (txtNotaUno.Text != "" && txtNotaDos.Text != "" && txtNotaTres.Text != "" && txtNombre.Text != "")
            {
                nota1 = Convert.ToDouble(txtNotaUno.Text);
                nota2 = Convert.ToDouble(txtNotaDos.Text);
                nota3 = Convert.ToDouble(txtNotaTres.Text);

                estudiante[i].notaFinal = (nota1 + nota2 + nota3);

                estudiante[i].nombre = txtNombre.Text;

                dataGridView1.Rows.Add(estudiante[i].nombre, estudiante[i].notaFinal);

                arbolBalanceado.InsertarDatos(estudiante[i].notaFinal);
                Refresh();

                txtNotaUno.Clear();
                txtNotaDos.Clear();
                txtNotaTres.Clear();
                txtNombre.Clear();

                i++;

                if (i == cantidad)
                {
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio.", "Aviso",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Eventos y botones del formulario
        private void ArbolBalanceadoForm_Paint(object sender, PaintEventArgs e)
        {
            arbolBalanceado.MostrarArbol(e, this.BackColor);
        }
        private void btnInOrden_Click(object sender, EventArgs e)
        {
            arbolBalanceado.InOrden(ListRecorrido);
        }
        private void btnPosOrden_Click(object sender, EventArgs e)
        {
            arbolBalanceado.PosOrden(ListRecorrido);
        }
        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            arbolBalanceado.PreOrden(ListRecorrido);
        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            cantidad = 0;
            i = 0;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox2.Enabled = true;
            dataGridView1.Rows.Clear();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            double x = 0;

            if (txtEliminarDato.Text != "")
            {
                x = Convert.ToDouble(txtEliminarDato.Text);
            }
            else
            {
                MessageBox.Show("Ingrese el dato que desea eliminar.");
            }

            if (arbolBalanceado.Eliminar(x))
            {
                Refresh();
                Eliminar(x);
            }
        }
        #endregion

        #region Eliminar del data grid view
        public void Eliminar(double x)
        {
            for (int i = 0; i < estudiante.Length; i++)
            {
                if (estudiante[i].notaFinal == x)
                {
                    for (int j = i; j < estudiante.Length - 1; j++)
                    {
                        estudiante[j].notaFinal = estudiante[j + 1].notaFinal;
                        estudiante[j].nombre = estudiante[j + 1].nombre;

                        if (j == estudiante.Length)
                        {
                            estudiante[j].notaFinal = Convert.ToDouble("");
                            estudiante[j].nombre = null;
                        }
                    }
                }
            }
            k--;
            dataGridView1.Rows.Clear();

            for (int i = 0; i < k; i++)
            {
                dataGridView1.Rows.Add(estudiante[i].nombre, estudiante[i].notaFinal);
            }
        }
        #endregion
    }
}
