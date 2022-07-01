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
    public partial class GrafosForm : Form
    {
        public GrafosForm()
        {
            InitializeComponent();
        }

        public long[,] matrizPesos;
        public int contador1 = 0, contador2 = 1;
        public int numero;
        CCaminoCorto camino = new CCaminoCorto();

        private void btnIngresarNumeros_Click(object sender, EventArgs e)
        {
            numero = Convert.ToInt32(txtNumeroVertices.Text);
            matrizPesos = new long[Convert.ToInt32(txtNumeroVertices.Text), Convert.ToInt32(txtNumeroVertices.Text)];
            MessageBox.Show("Continue ingresando las distancias de los vertices");
            comboBox1.Enabled = true;
            btnConfirmar.Enabled = true;
            txtNumeroVertices.Enabled = false;
            btnIngresarNumeros.Enabled = false;
            label8.Text = Convert.ToString(contador1 + 1);
            label10.Text = Convert.ToString(contador2 + 1);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "No")
            {
                MessageBox.Show("No existe una distancia entre los vertices " + (contador1 + 1) + " y " + (contador2 + 1));
                comboBox1.Text = "";
                matrizPesos[contador1, contador2] = 999999999;
                contador2++;
                if (contador1 == contador2)
                {
                    matrizPesos[contador1, contador2] = 0;
                    contador2++;
                }
                if (contador2 != numero)
                {
                    label10.Text = Convert.ToString(contador2 + 1);
                }
                else
                {
                    contador2 = 0;
                    MessageBox.Show("Se han completado las distancias del vertice " + (contador2 + 1) + " Continue con el ste vertice");
                    label10.Text = Convert.ToString(contador2 + 1);
                    contador1++;
                    if (contador1 == numero)
                    {
                        label8.Visible = false;
                        label10.Visible = false;
                        comboBox1.Enabled = false;
                        btnIngresarDistancia.Enabled = false;
                        btnConfirmar.Enabled = false;
                        contador1 = 0;
                        MessageBox.Show("Se ha completado la matriz de distancis");
                        btnCaminosCortos.Enabled = true;
                        comboBox1.Enabled = false;
                    }
                    else
                    {
                        label8.Text = Convert.ToString(contador1 + 1);
                    }
                }
            }
            else
            {
                comboBox1.Text = "";
                btnIngresarDistancia.Enabled = true;
                txtDistancia.Enabled = true;
                label4.Text = Convert.ToString(contador1 + 1);
                label6.Text = Convert.ToString(contador2 + 1);
                MessageBox.Show("Si existe distancia del vertice " + (contador1 + 1) + " al vertice " + (contador2 + 1) +
                    " , continue a ingresar la distancia");
            }
        }

        private void btnIngresarDistancia_Click(object sender, EventArgs e)
        {
            matrizPesos[contador1, contador2] = int.Parse(txtDistancia.Text);
            txtDistancia.Clear();
            btnIngresarDistancia.Enabled = false;
            label4.Enabled = false;
            label6.Visible = false;
            MessageBox.Show("Distancia ingresada");
            contador2++;

            if (contador1 == contador2)
            {
                matrizPesos[contador1, contador2] = 0;
                contador2++;
            }
            if (contador2 != numero)
            {
                label10.Text = Convert.ToString(contador2 + 1);
            }
            else
            {
                contador2 = 0;
                MessageBox.Show("Se han completado las distancias del vertice " + (contador1 + 1) + " continue con el ste vertice");
                label10.Text = Convert.ToString(contador2 + 1);
                contador1++;
                if (contador1 == numero)
                {
                    label8.Visible = false;
                    label10.Visible = false;
                    comboBox1.Enabled = false;
                    btnIngresarDistancia.Enabled = false;
                    txtDistancia.Enabled = false;
                    contador1 = 0;
                    MessageBox.Show("Se ha completado al matriz de distancias");
                    btnIngresarDistancia.Visible = true;
                    btnCaminosCortos.Enabled = true;
                }
                else
                {
                    label8.Text = Convert.ToString(contador1 + 1);
                }
            }
        }

        private void btnCaminosCortos_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = camino.AlgoritmoFloyd(matrizPesos, numero);
        }
    }
}
