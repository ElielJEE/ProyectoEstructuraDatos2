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
    class CArbol
    {
        public CNodo raiz;

        Graphics nodo;
        Font font;

        int posY = 50;
        int posX = 580;

        bool encontrado = false;

        public CArbol()
        {
            raiz = null;
        }
        public CArbol(Graphics nodo, Font font)
        {
            this.nodo = nodo;
            this.font = font;
        }

        #region Metodo para insertar los datos
        public void InsertarDatos(double notaFinal)
        {
            CNodo temp = new CNodo();

            temp.notaFinal = notaFinal;
            temp.izquierdo = null;
            temp.derecho = null;

            if (raiz == null)
            {
                raiz = temp;
                temp.nivel = 1;
            }
            else
            {
                CNodo anterior = null, ant;
                ant = raiz;

                while (ant != null)
                {
                    anterior = ant;
                    if (notaFinal <= ant.notaFinal)
                    {
                        ant = ant.izquierdo;
                    }
                    else
                    {
                        ant = ant.derecho;
                    }
                }
                if (notaFinal <= anterior.notaFinal)
                {
                    temp.nivel++;
                    anterior.izquierdo = temp;
                }
                else if (notaFinal > anterior.notaFinal)
                {
                    temp.nivel++;
                    anterior.derecho = temp;
                }
            }
        }
        #endregion

        #region Metodo para Mostrar el arbol
        public void MostrarArbol(PaintEventArgs e, Color c)
        {
            e.Graphics.Clear(c);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            nodo = e.Graphics;
            DibujarArbol(nodo, font, Brushes.LightGray, Brushes.Black, Pens.Black, Brushes.Black);
        }
        #endregion

        #region Metodos para eliminar el nodo
        public bool Eliminar(double notaFinal)
        {
            raiz = EliminarNodo(raiz, notaFinal);
            return encontrado;
        }

        public CNodo EliminarNodo(CNodo Raiz, double notaFinal)
        {
            if (Raiz == null)
            {
                MessageBox.Show("No se ha encontrado el nodo a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                encontrado = false;
            }
            else if (notaFinal < Raiz.notaFinal)
            {
                CNodo izq = EliminarNodo(Raiz.izquierdo, notaFinal);
                Raiz.izquierdo = izq;
            }
            else if (notaFinal > Raiz.notaFinal)
            {
                CNodo der = EliminarNodo(Raiz.derecho, notaFinal);
                Raiz.derecho = der;
            }
            else
            {
                CNodo aux = Raiz;

                if (aux.derecho == null)
                {
                    Raiz = aux.izquierdo;
                }
                else if (aux.izquierdo == null)
                {
                    Raiz = aux.derecho;
                }
                else
                {
                    aux = Cambiar(aux);
                }
                aux = null;
                encontrado = true;
            }
            return Raiz;
        }
        #endregion

        #region Metodo para dibujar el arbol
        public void DibujarArbol(Graphics grafico, Font fuente, Brush colorRelleno, Brush colorFuente, Pen relacion, Brush borde)
        {
            if (raiz == null)
            {
                return;
            }

            raiz.UbicacionNodo(posX, posY);
            raiz.DibujarRamas(grafico, relacion);
            raiz.DibujarNodo(grafico, fuente, colorRelleno, colorFuente, relacion, borde);

        }
        #endregion

        #region Metodo para cambiar el nodo al eliminar otro
        protected CNodo Cambiar(CNodo aux)
        {
            CNodo nodo = aux;
            CNodo nodo2 = aux.izquierdo;

            while (nodo2.derecho != null)
            {
                nodo = nodo2;
                nodo2 = nodo2.derecho;
            }
            aux.notaFinal = nodo2.notaFinal;

            if (nodo == aux)
            {
                nodo.izquierdo = nodo2.izquierdo;
            }
            else
            {
                nodo.derecho = nodo2.izquierdo;
            }
            return nodo2;
        }
        #endregion

        #region InOrden
        public void InOrden(ListBox list)
        {
            list.Items.Clear();
            InOrden(raiz, list);
        }
        public void InOrden(CNodo nodo, ListBox list)
        {
            if (nodo != null)
            {
                InOrden(nodo.izquierdo, list);
                list.Items.Add(nodo.notaFinal.ToString());
                InOrden(nodo.derecho, list);
            }
        }
        #endregion

        #region PosOrden
        public void PosOrden(ListBox list)
        {
            list.Items.Clear();
            PosOrden(raiz, list);
        }
        public void PosOrden(CNodo nodo, ListBox list)
        {
            if (nodo != null)
            {
                PosOrden(nodo.izquierdo, list);
                PosOrden(nodo.derecho, list);
                list.Items.Add(nodo.notaFinal.ToString());
            }
        }
        #endregion

        #region PreOrden
        public void PreOrden(ListBox list)
        {
            list.Items.Clear();
            PreOrden(raiz, list);
        }
        public void PreOrden(CNodo nodo, ListBox list)
        {
            if (nodo != null)
            {
                list.Items.Add(nodo.notaFinal.ToString());
                PreOrden(nodo.izquierdo, list);
                PreOrden(nodo.derecho, list);
            }
        }
        #endregion

    }
}
