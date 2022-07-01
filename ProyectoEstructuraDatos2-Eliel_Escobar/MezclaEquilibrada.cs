using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuraDatos2_Eliel_Escobar
{
    class MezclaEquilibrada
    {
        TextWriter nuevoArchivoTexto;
        int numArchivo;

        public void LeerArchivo(DataGridView dgv, string ruta)
        {
            StreamReader reader = new StreamReader(ruta);
            dgv.Rows.Clear();

            string elementosTexto = reader.ReadToEnd();
            string[] lineas = elementosTexto.Split('\r');

            int[] elementosNumeros = Array.ConvertAll(lineas, 
                item => int.Parse(item));
            int tamanio = elementosNumeros.Length;

            Ordenamiento(elementosNumeros, 0, tamanio - 1);


            foreach (var item in elementosNumeros)
            {
                dgv.Rows.Add(item, null);
            }

            reader.Close();
        }

        public void CrearArchivoTexto()
        {
            nuevoArchivoTexto = new StreamWriter($"Archivo{numArchivo = 0}.txt");
            MessageBox.Show($"El Archivo F{numArchivo = 0} se creo.");
        }

        public void MostrarData(DataGridView dgv, int[] array)
        {
            int tamanio = array.Length;
            Ordenamiento(array, 0, tamanio - 1);

            foreach (var item in array)
            {
                dgv.Rows.Add(item, null);
                nuevoArchivoTexto.WriteLine(item);
            }
            nuevoArchivoTexto.Close();
        }

        public void MetodoMezclaEquilibrada(int[] array, int izq, int mitad, int der)
        {
            int[] aux = new int[100];
            int i, izqFinal, elementos, aux2;

            izqFinal = (mitad - 1);
            aux2 = izq;
            elementos = (der - izq + 1);

            while ((izq <= izqFinal) && (mitad <= der))
            {
                if (array[izq] <= array[mitad])
                    aux[aux2++] = array[izq++];
                else
                    aux[aux2++] = array[mitad++];
            }
            while (izq <= izqFinal)
            {
                aux[aux2++] = array[izq++];
            }
            while (mitad <= der)
            {
                aux[aux2++] = array[mitad++];
            }
            for (i = 0; i < elementos; i++)
            {
                array[der] = aux[der];
                der--;
            }
        }

        public void Ordenamiento(int[] numeros, int izq, int der)
        {
            int mitad;
            if (der > izq)
            {
                mitad = (der + izq) / 2;
                Ordenamiento(numeros, izq, mitad);
                Ordenamiento(numeros, (mitad + 1), der);
                MetodoMezclaEquilibrada(numeros, izq, (mitad + 1), der);
            }
        }
    }
}
