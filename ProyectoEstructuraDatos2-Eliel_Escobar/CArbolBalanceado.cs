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
    class CArbolBalanceado
    {
        public CNodo raiz;

        Graphics nodo;
        Font font;

        int posY = 50;
        int posX = 580;

        bool encontrado = false;

        public CArbolBalanceado()
        {
            raiz = null;
        }
        public CArbolBalanceado(Graphics nodo, Font font)
        {
            this.nodo = nodo;
            this.font = font;
        }

        #region Insertar Nodo
        public void InsertarDatos(double notaFinal)
        {
            CNodo nuevo = new CNodo(notaFinal);

            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                raiz = Insertar(nuevo, raiz);
            }
        }
        public CNodo Insertar(CNodo nuevo, CNodo subArbol)
        {
            CNodo nuevoPadre = subArbol;

            if (nuevo.notaFinal < subArbol.notaFinal)
            {
                if (subArbol.izquierdo == null)
                {
                    subArbol.izquierdo = nuevo;
                }
                else
                {
                    subArbol.izquierdo = Insertar(nuevo, subArbol.izquierdo);
                    if (FactorEquilibrio(subArbol.izquierdo) - FactorEquilibrio(subArbol.derecho) == 2)
                    {
                        if (nuevo.notaFinal < subArbol.izquierdo.notaFinal)
                        {
                            nuevoPadre = RotacionIzquierda(subArbol);
                        }
                        else
                        {
                            nuevoPadre = IzquierdaIzquierda(subArbol);
                        }
                    }
                }
            }
            else if (nuevo.notaFinal >= subArbol.notaFinal)
            {
                if (subArbol.derecho == null)
                {
                    subArbol.derecho = nuevo;
                }
                else
                {
                    subArbol.derecho = Insertar(nuevo, subArbol.derecho);
                    if (FactorEquilibrio(subArbol.derecho) - FactorEquilibrio(subArbol.izquierdo) == 2)
                    {
                        if (nuevo.notaFinal > subArbol.derecho.notaFinal)
                        {
                            nuevoPadre = RotacionDerecha(subArbol);
                        }
                        else
                        {
                            nuevoPadre = DerechaDerecha(subArbol);
                        }
                    }
                }
            }
            if ((subArbol.izquierdo == null) && (subArbol.derecho != null))
            {
                subArbol.factorEquilibrio = subArbol.derecho.factorEquilibrio + 1;
            }
            else if ((subArbol.derecho == null) && (subArbol.izquierdo != null))
            {
                subArbol.factorEquilibrio = subArbol.izquierdo.factorEquilibrio + 1;
            }
            else
            {
                subArbol.factorEquilibrio = Math.Max(FactorEquilibrio(subArbol.izquierdo), FactorEquilibrio(subArbol.derecho)) + 1;
            }
            return nuevoPadre;
        }
        #endregion

        #region Factor Equilibrio
        private int FactorEquilibrio(CNodo x)
        {
            if (x == null)
            {
                return -1;
            }
            else
            {
                return x.factorEquilibrio;
            }
        }
        #endregion

        #region Metodos de Rotaciones
        private CNodo RotacionIzquierda(CNodo x)
        {
            CNodo auxiliar = x.izquierdo;
            x.izquierdo = auxiliar.derecho;
            auxiliar.derecho = x;
            x.factorEquilibrio = Math.Max(FactorEquilibrio(x.izquierdo), FactorEquilibrio(x.derecho)) + 1;
            auxiliar.factorEquilibrio = Math.Max(FactorEquilibrio(auxiliar.izquierdo), FactorEquilibrio(auxiliar.derecho)) + 1;
            MessageBox.Show("Se aplico la Rotacion: Izquierda-Derecha", "aviso");
            return auxiliar;
        }
        private CNodo RotacionDerecha(CNodo x)
        {
            CNodo auxiliar = x.derecho;
            x.derecho = auxiliar.izquierdo;
            auxiliar.izquierdo = x;
            x.factorEquilibrio = Math.Max(FactorEquilibrio(x.izquierdo), FactorEquilibrio(x.derecho)) + 1;
            auxiliar.factorEquilibrio = Math.Max(FactorEquilibrio(auxiliar.izquierdo), FactorEquilibrio(auxiliar.derecho)) + 1;
            MessageBox.Show("Se aplico la Rotacion: Derecha-Izquierda", "aviso");
            return auxiliar;
        }

        private CNodo DerechaDerecha(CNodo x)
        {
            CNodo temp;
            x.derecho = RotacionIzquierda(x.derecho);
            temp = RotacionDerecha(x);
            MessageBox.Show("Se aplico la Rotacion: Derecha-Derecha", "aviso");
            return temp;
        }

        private CNodo IzquierdaIzquierda(CNodo x)
        {
            CNodo temp;
            x.izquierdo = RotacionDerecha(x.izquierdo);
            temp = RotacionIzquierda(x);
            MessageBox.Show("Se aplico la Rotacion: Izquierda-Izquierda", "aviso");
            return temp;
        }
        #endregion

        #region Metodos para dibujar el arbol
        public void MostrarArbol(PaintEventArgs e, Color c)
        {
            e.Graphics.Clear(c);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            nodo = e.Graphics;
            DibujarArbol(nodo, font, Brushes.LightGray, Brushes.Black, Pens.Black, Brushes.Black);
        }
        private void DibujarArbol(Graphics grafico, Font fuente, Brush colorRelleno, Brush colorFuente, Pen relacion, Brush borde)
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

        #region Metodos para eliminar nodo
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
        public CNodo Cambiar(CNodo aux)
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
