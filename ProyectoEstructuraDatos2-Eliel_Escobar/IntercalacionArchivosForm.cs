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
    public partial class IntercalacionArchivosForm : Form
    {
        public IntercalacionArchivosForm()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnOrdenar.Enabled = false;
            btnReiniciar.Enabled = false;
        }

        TextWriter archivo;

        int numArchivo = 1, cantidad, cantF1, cantF2, i = 0;

        int[] elementos;

        public void CrearArchivos()
        {
            MessageBox.Show($"El archivo F{numArchivo} ha sido creado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (numArchivo == 1)
            {
                archivo = new StreamWriter($"archivo{numArchivo}.txt");
            }
            else
            {
                archivo = new StreamWriter("archivo2.txt");
            }

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            btnCrear.Enabled = false;
            btnReiniciar.Enabled = true;
            txtCantidad.Focus();
            txtCantidad.Clear();
        }

        public void RegistrarElementos()
        {
            int elemento;

            if (i != cantidad && txtElementos.Text != "")
            {
                elemento = Convert.ToInt32(txtElementos.Text);

                if (elemento <= 0 || txtElementos.Text.Length > 8)
                {
                    MessageBox.Show("El valor ingresado no es valido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    elementos[i] = elemento;
                    i++;
                }

                if (i == cantidad)
                {
                    AgregarElementos(elementos);
                    groupBox2.Enabled = false;
                }

                if (i == cantidad && numArchivo == 2)
                {
                    MessageBox.Show($"Pulse el boton Crear nuevamente para crear el archivo F{numArchivo}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (i == cantidad && numArchivo == 3)
                {
                    btnOrdenar.Enabled = true;
                }
                txtElementos.Clear();
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }


        public void AgregarElementos(int[] elementos)
        {
            int auxElemento, j;

            for (int i = (elementos.Length - 1); i > 0; i--)
            {
                for (j = (i - 1); j >= 0; j--)
                {
                    if (elementos[i] < elementos[j])
                    {
                        auxElemento = elementos[i];
                        elementos[i] = elementos[j];
                        elementos[j] = auxElemento;
                    }
                }
            }

            foreach (int elemento in elementos)
            {
                if (numArchivo == 1)
                {
                    dgvF1.Rows.Add(elemento, null);
                }
                else
                {
                    dgvF2.Rows.Add(elemento, null);
                }

                archivo.WriteLine(elemento);
            }

            archivo.Close();
            btnCrear.Enabled = true;

            if (numArchivo == 1)
            {
                numArchivo = 2;
            }
            else
            {
                numArchivo = 3;
                btnCrear.Enabled = false;
            }
        }


        public void IntercalacionArchivos()
        {
            StreamReader leerArchivo1 = new StreamReader("archivo1.txt");
            StreamReader leerArchivo2 = new StreamReader("archivo2.txt");
            TextWriter archivo3 = new StreamWriter("archivo3.txt");

            int[] f1 = new int[cantF1 + 1];
            int[] f2 = new int[cantF2 + 1];

            int i = 0, j = 0, k;

            while (!leerArchivo1.EndOfStream)
            {
                f1[i] = Convert.ToInt32(leerArchivo1.ReadLine());
                i++;
            }

            while (!leerArchivo2.EndOfStream)
            {
                f2[j] = Convert.ToInt32(leerArchivo2.ReadLine());
                j++;
            }

            for (i = k = j = 0; i < (f1.Length - 1) && j < (f2.Length - 1); k++)
            {
                if (f1[i] < f2[j])
                {
                    archivo3.WriteLine(f1[i]);
                    i++;
                }
                else
                {
                    archivo3.WriteLine(f2[j]);
                    j++;
                }
            }

            for (; i < f1.Length - 1; i++)
            {
                archivo3.WriteLine(f1[i]);
            }
            for (; j < f2.Length - 1; j++)
            {
                archivo3.WriteLine(f2[j]);
            }

            leerArchivo1.Close();
            leerArchivo2.Close();
            archivo3.Close();

            StreamReader leerArchivo3 = new StreamReader("archivo3.txt");
            while (!leerArchivo3.EndOfStream)
            {
                dgvF3.Rows.Add(leerArchivo3.ReadLine());
            }
            leerArchivo3.Close();
            btnOrdenar.Enabled = false;
        }

        public void Cantidad()
        {
            i = 0;
            if (txtCantidad.Text != "")
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
                if (cantidad <= 0 || txtCantidad.Text.Length > 8 || txtCantidad.Text == "")
                {
                    MessageBox.Show("La cantidad de elementos ingresada no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    elementos = new int[cantidad];
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    txtElementos.Focus();

                    if (numArchivo == 1)
                    {
                        cantF1 = cantidad;
                    }

                    else
                    {
                        cantF2 = cantidad;
                    }

                }
            }
            else
            {
                MessageBox.Show("El campo no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearArchivos();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Cantidad();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RegistrarElementos();
        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            numArchivo = 1;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnCrear.Enabled = true;
            btnReiniciar.Enabled = false;
            dgvF1.Rows.Clear();
            dgvF2.Rows.Clear();
            dgvF3.Rows.Clear();
            btnOrdenar.Enabled = false;
            MessageBox.Show("Se ha creado un nuevo registro!", "Estado de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            IntercalacionArchivos();
        }
    }
}
