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
    public partial class FormOrdenInterna : Form
    {
        public FormOrdenInterna()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            btnReiniciar.Enabled = false;
        }

        #region Mezcla Equilibrada
        private void opMezclaEquilibrada_Click(object sender, EventArgs e)
        {
            MezclaEquilibradaForm mezcla = new MezclaEquilibradaForm();
            mezcla.Show();
        }
        #endregion

        #region Arbol Binario
        private void arbolBinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArbolBinarioForm arbol = new ArbolBinarioForm();
            arbol.Show();
        }
        #endregion

        #region Arbol Balanceado
        private void arbolBalanceadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArbolBalanceadoForm arbolBalanceado = new ArbolBalanceadoForm();
            arbolBalanceado.Show();
        }
        #endregion

        #region Intercalacion de Archivos
        private void intercalacionDeArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntercalacionArchivosForm intercalacion = new IntercalacionArchivosForm();
            intercalacion.ShowDialog();
        }
        #endregion

        int cantidad = 0, i = 0;

        struct Estudiantes
        {
            public int nota, edad;
            public string nombre, anio, seccion;
        }
        Estudiantes[] estudiante;

        XForm X = new XForm();

        #region Boton para aceptar cantidad
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
                estudiante = new Estudiantes[cantidad];

                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                btnReiniciar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Agregue una cantidad de estudiantes.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Boton para agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNota.Text != "" && txtNombre.Text != "" && txtEdad.Text != "" 
                && txtAnio.Text != "" && txtSeccion.Text != "")
            {
                estudiante[i].nota = Convert.ToInt32(txtNota.Text);
                estudiante[i].nombre = txtNombre.Text;
                estudiante[i].edad = Convert.ToInt32(txtEdad.Text);
                estudiante[i].anio = txtAnio.Text;
                estudiante[i].seccion = txtSeccion.Text;

                dataGridView1.Rows.Add(estudiante[i].nota, estudiante[i].nombre,
                    estudiante[i].edad, estudiante[i].anio, estudiante[i].seccion);

                txtNota.Clear();
                txtNombre.Clear();
                txtEdad.Clear();
                txtAnio.Clear();
                txtSeccion.Clear();

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

        #region Boton para reiniciar
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            cantidad = 0;
            i = 0;
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            dataGridView1.Rows.Clear();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }
        #endregion

        #region Mostrar En Data GridView
        public void MostrarData()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < cantidad; i++)
            {
                dataGridView1.Rows.Add(estudiante[i].nota, estudiante[i].nombre,
                    estudiante[i].edad, estudiante[i].anio, estudiante[i].seccion);
            }
        }

        public void MostrarEncontradoData(int pCarnet, string pNombre, int pEdad, string pAnio, string pSeccion)
        {
            dataGridView2.Rows.Add(pCarnet, pNombre, pEdad, pAnio, pSeccion);
        }
        #endregion

        #region Seleccion Directa
        public void SeleccionDirecta()
        {
            for (int i = 0; i < estudiante.Length - 1; i++)
            {
                int menorCarnet = estudiante[i].nota;
                string menorNombre = estudiante[i].nombre;
                int menorEdad = estudiante[i].edad;
                string menorAnio = estudiante[i].anio;
                string menorSeccion = estudiante[i].seccion;
                int k = i;

                for (int j = i + 1; j <= estudiante.Length - 1; j++)
                {
                    if (estudiante[j].nota < menorCarnet)
                    {
                        menorCarnet = estudiante[j].nota;
                        menorNombre = estudiante[j].nombre;
                        menorEdad = estudiante[j].edad;
                        menorAnio = estudiante[j].anio;
                        menorSeccion = estudiante[j].seccion;
                        k = j;
                    }
                }

                estudiante[k].nota = estudiante[i].nota;
                estudiante[i].nota = menorCarnet;

                estudiante[k].nombre = estudiante[i].nombre;
                estudiante[i].nombre = menorNombre;

                estudiante[k].edad = estudiante[i].edad;
                estudiante[i].edad = menorEdad;

                estudiante[k].anio = estudiante[i].anio;
                estudiante[i].anio = menorAnio;

                estudiante[k].seccion = estudiante[i].seccion;
                estudiante[i].seccion = menorSeccion;
            }

            MostrarData();
        }
        private void btnSelecDir_Click(object sender, EventArgs e)
        {
            SeleccionDirecta();
        }


        #endregion

        #region Shell
        public void Shell()
        {
            int mitad;
            bool ejecutarPasadas;
            int auxNota, auxEdad;
            string auxNombre, auxAnio, auxSeccion;
            mitad = cantidad / 2;
            while (mitad > 0)
            {
                ejecutarPasadas = true;
                while (ejecutarPasadas)
                {
                    ejecutarPasadas = false;
                    for (i = 1; i <= (cantidad - mitad); i++)
                    {
                        if (estudiante[i - 1].nota < estudiante[(i - 1) + mitad].nota)
                        {
                            auxNota = estudiante[(i - 1) + mitad].nota;
                            estudiante[(i - 1) + mitad].nota = estudiante[i - 1].nota;
                            estudiante[i - 1].nota = auxNota;

                            auxNombre = estudiante[(i - 1) + mitad].nombre;
                            estudiante[(i - 1) + mitad].nombre = estudiante[i - 1].nombre;
                            estudiante[i - 1].nombre = auxNombre;

                            auxEdad = estudiante[(i - 1) + mitad].edad;
                            estudiante[(i - 1) + mitad].edad = estudiante[i - 1].edad;
                            estudiante[i - 1].edad = auxEdad;

                            auxAnio = estudiante[(i - 1) + mitad].anio;
                            estudiante[(i - 1) + mitad].anio = estudiante[i - 1].anio;
                            estudiante[i - 1].anio = auxAnio;

                            auxSeccion = estudiante[(i - 1) + mitad].seccion;
                            estudiante[(i - 1) + mitad].seccion = estudiante[i - 1].seccion;
                            estudiante[i - 1].seccion = auxSeccion;

                            ejecutarPasadas = true;
                        }
                    }
                }
                mitad = mitad / 2;
            }
            MostrarData();
        }
        private void btnShell_Click(object sender, EventArgs e)
        {
            Shell();
        }

        #endregion

        #region Buqueda Binaria

        // Solo funciona si estan ordenanos de manera ascendente
        public void BusquedaBinaria(int X)
        {
            int xNota = X;
            bool encontrado = false;
            int izq = 0, der = estudiante.Length - 1;

            while (izq <= der && ! encontrado)
            {
                int centro = izq + (der - izq) / 2;
                if (estudiante[centro].nota == xNota)
                {
                    encontrado = true;
                    MostrarEncontradoData(estudiante[centro].nota, estudiante[centro].nombre,
                        estudiante[centro].edad, estudiante[centro].anio, estudiante[centro].seccion);
                }
                else if (estudiante[centro].nota < xNota)
                {
                    izq = centro + 1;
                }
                else
                {
                    der = centro - 1;
                }
            }
            if (!encontrado)
            {
                MessageBox.Show("Estudiante no encontrado.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBusquedaBinaria_Click(object sender, EventArgs e)
        {
            X.ShowDialog();
            BusquedaBinaria(X.nota);
        }
        #endregion

        #region Metodos Para HeapSort
        public void Ordenar(int tamanio, int posicion)
        {
            int izq = (posicion + 1) * 2 - 1;
            int der = (posicion + 1) * 2;
            int mayor;

            if (izq < tamanio && estudiante[izq].nota > estudiante[posicion].nota)
            {
                mayor = izq;
            }
            else
            {
                mayor = posicion;
            }

            if (der < tamanio && estudiante[der].nota > estudiante[mayor].nota)
            {
                mayor = der;
            }

            if (mayor != posicion)
            {
                int auxNota = estudiante[posicion].nota;
                estudiante[posicion].nota = estudiante[mayor].nota;
                estudiante[mayor].nota = auxNota;

                string auxNombre = estudiante[posicion].nombre;
                estudiante[posicion].nombre = estudiante[mayor].nombre;
                estudiante[mayor].nombre = auxNombre;

                int auxEdad = estudiante[posicion].edad;
                estudiante[posicion].edad = estudiante[mayor].edad;
                estudiante[mayor].edad = auxEdad;

                string auxAnio = estudiante[posicion].anio;
                estudiante[posicion].anio = estudiante[mayor].anio;
                estudiante[mayor].anio = auxAnio;

                string auxSeccion = estudiante[posicion].seccion;
                estudiante[posicion].seccion = estudiante[mayor].seccion;
                estudiante[mayor].seccion = auxSeccion;

                Ordenar(tamanio, mayor);
            }
        }

        public void InsertarMonticulo(int ultimoPadre, int tamanioArray)
        {
            if (ultimoPadre >= 0)
            {
                Ordenar(tamanioArray, ultimoPadre);
                ultimoPadre--;
                InsertarMonticulo(ultimoPadre, tamanioArray);
                MostrarData();
            }
        }

        public void EliminarMonticulo(int tamanioArray)
        {
            if (tamanioArray - 1 > 0)
            {
                int n = tamanioArray - 1;

                int auxNota = estudiante[n].nota;
                estudiante[n].nota = estudiante[0].nota;
                estudiante[0].nota = auxNota;

                string auxNombre = estudiante[n].nombre;
                estudiante[n].nombre = estudiante[0].nombre;
                estudiante[0].nombre = auxNombre;

                int auxEdad = estudiante[n].edad;
                estudiante[n].edad = estudiante[0].edad;
                estudiante[0].edad = auxEdad;

                string auxAnio = estudiante[n].anio;
                estudiante[n].anio = estudiante[0].anio;
                estudiante[0].anio = auxAnio;

                string auxSeccion = estudiante[n].seccion;
                estudiante[n].seccion = estudiante[0].seccion;
                estudiante[0].seccion = auxSeccion;

                tamanioArray--;
                Ordenar(tamanioArray, 0);
                EliminarMonticulo(tamanioArray);
                MostrarData();
            }
        }
        private void btnHeapSort_Click(object sender, EventArgs e)
        {
            int tamanioArray = cantidad;
            int ultimoPadre = (tamanioArray - 1) / 2;
            MessageBox.Show("Inicia insercion en el monticulo");
            InsertarMonticulo(ultimoPadre, tamanioArray);
            MessageBox.Show("Inicia eliminacion del monticulo");
            EliminarMonticulo(tamanioArray);
        }
        #endregion

        #region Quicksort
        public void Quicksort(int inicio, int fin)
        {
            int x, y, central;
            double pivote;
            central = (inicio + fin) / 2;
            pivote = estudiante[central].nota;
            x = inicio;
            y = fin;

            do
            {
                while (estudiante[x].nota < pivote) x++;
                while (estudiante[y].nota > pivote) y--;

                if (x <= y)
                {
                    int auxCarnet = estudiante[x].nota;
                    estudiante[x].nota = estudiante[y].nota;
                    estudiante[y].nota = auxCarnet;

                    string auxNombre = estudiante[x].nombre;
                    estudiante[x].nombre = estudiante[y].nombre;
                    estudiante[y].nombre = auxNombre;

                    int auxEdad = estudiante[x].edad;
                    estudiante[x].edad = estudiante[y].edad;
                    estudiante[y].edad = auxEdad;

                    string auxAnio = estudiante[x].anio;
                    estudiante[x].anio = estudiante[y].anio;
                    estudiante[y].anio = auxAnio;

                    string auxSeccion = estudiante[x].seccion;
                    estudiante[x].seccion = estudiante[y].seccion;
                    estudiante[y].seccion = auxSeccion;

                    x++;
                    y--;
                }
            } while (x <= y);

            if (inicio < y)
            {
                Quicksort(inicio, y);
            }
            if (x < fin)
            {
                Quicksort(x, fin);
            }
            MostrarData();
        }

        private void btnQuicksort_Click(object sender, EventArgs e)
        {
            Quicksort(0, estudiante.Length - 1);
        }
        #endregion

        #region Burbuja
        public void OrdenamientoBurbuja(int j, int i)
        {
            int auxNota, auxEdad;
            string auxNombre, auxAnio, auxSeccion;

            if (j >= i)
            {
                if (estudiante[j - 1].nota > estudiante[j].nota)
                {
                    auxNota = estudiante[j - 1].nota;
                    estudiante[j - 1].nota = estudiante[j].nota;
                    estudiante[j].nota = auxNota;

                    auxNombre = estudiante[j - 1].nombre;
                    estudiante[j - 1].nombre = estudiante[j].nombre;
                    estudiante[j].nombre = auxNombre;

                    auxEdad = estudiante[j - 1].edad;
                    estudiante[j - 1].edad = estudiante[j].edad;
                    estudiante[j].edad = auxEdad;

                    auxAnio = estudiante[j - 1].anio;
                    estudiante[j - 1].anio = estudiante[j].anio;
                    estudiante[j].anio = auxAnio;

                    auxSeccion = estudiante[j - 1].seccion;
                    estudiante[j - 1].seccion = estudiante[j].seccion;
                    estudiante[j].seccion = auxSeccion;
                }
                j--;
                OrdenamientoBurbuja(j, i);
            }
        }

        public void Burbuja(int tamanioArray, int i)
        {
            if (i < tamanioArray)
            {
                OrdenamientoBurbuja(tamanioArray - 1, i);
                i++;
                Burbuja(tamanioArray, i);
                MostrarData();
            }
        }

        private void btnBurbuja_Click(object sender, EventArgs e)
        {
            int tamanioArray = cantidad;
            int i = 1;
            Burbuja(tamanioArray, i);
        }

        #endregion

        #region Baraja
        public void MetodoBaraja(int i)
        {
            int j;
            int auxNota, auxEdad;
            string auxNombre, auxAnio, auxSeccion;

            auxNota = estudiante[i].nota;
            auxNombre = estudiante[i].nombre;
            auxEdad = estudiante[i].edad;
            auxAnio = estudiante[i].anio;
            auxSeccion = estudiante[i].seccion;
            j = i - 1;

            OrdenamientoBaraja(j, auxNota, auxEdad, auxNombre, auxAnio, auxSeccion);
        }
        public void OrdenamientoBaraja(int j, int auxNota, int auxEdad, string auxNombre, string auxAnio, string auxSeccion)
        {
            if (j >= 0 && estudiante[j].nota > auxNota)
            {
                estudiante[j + 1].nota = estudiante[j].nota;
                estudiante[j + 1].nombre = estudiante[j].nombre;
                estudiante[j + 1].edad = estudiante[j].edad;
                estudiante[j + 1].anio = estudiante[j].anio;
                estudiante[j + 1].seccion = estudiante[j].seccion;
                j--;
                OrdenamientoBaraja(j, auxNota, auxEdad, auxNombre, auxAnio, auxSeccion);
            }
            else
            {
                estudiante[j + 1].nota = auxNota;
                estudiante[j + 1].nombre = auxNombre;
                estudiante[j + 1].edad = auxEdad;
                estudiante[j + 1].anio = auxAnio;
                estudiante[j + 1].seccion = auxSeccion;
            }
        }
        public void Baraja(int tamanioArray, int i)
        {
            if (i < tamanioArray)
            {
                MetodoBaraja(i);
                i++;
                Baraja(tamanioArray, i);
                MostrarData();
            }
        }
        private void btnBaraja_Click(object sender, EventArgs e)
        {
            int tamanioArray = cantidad;
            int i = 0;
            Baraja(tamanioArray, i);
        }
        #endregion

        #region Busqueda Secuelcial
        public void BusquedadSecuencial(int X, int i)
        {
            int xNota = X;
            bool encontrado = false;

            while (!encontrado && i < cantidad)
            {
                if (estudiante[i].nota == xNota)
                {
                    encontrado = true;
                    MostrarEncontradoData(estudiante[i].nota, estudiante[i].nombre,
                        estudiante[i].edad, estudiante[i].anio, estudiante[i].seccion);
                } i++;
            }
            if (!encontrado)
            {
                MessageBox.Show("Estudiante no encontrado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnBusquedaSecuencial_Click(object sender, EventArgs e)
        {
            X.ShowDialog();
            int i = 0;
            BusquedadSecuencial(X.nota, i);
        }
        #endregion
        private void grafosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrafosForm grafos = new GrafosForm();
            grafos.ShowDialog();
        }
    }
}
