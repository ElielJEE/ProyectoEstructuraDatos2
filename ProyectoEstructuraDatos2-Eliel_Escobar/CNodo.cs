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
    class CNodo
    {
        public CNodo izquierdo { get; set; }
        public CNodo derecho { get; set; }
        public double notaFinal;
        public int factorEquilibrio;

        int coordenadasX = 100,
            coordenadasY = 10,
            coordenadasXderecho,
            coordenadasYderecho,
            elipse = 35;

        public int nivel { get; set; }

        public CNodo(double NFinal)
        {
            notaFinal = NFinal;
            factorEquilibrio = 0;
            izquierdo = null;
            derecho = null;
        }

        public CNodo()
        {
            notaFinal = 0;
            factorEquilibrio = 0;
            izquierdo = null;
            derecho = null;
        }

        public CNodo(double dato, CNodo izquierdo, CNodo derecho, CNodo Padre)
        {
            notaFinal = dato;
            this.izquierdo = izquierdo;
            this.derecho = derecho;
        }

        #region Ubicar el nodo
        public void UbicacionNodo(int posX, int posY)
        {
            int aux1,
                aux2;

            coordenadasYderecho = Convert.ToInt32(posY + elipse / 2);

            if (izquierdo != null)
            {
                izquierdo.UbicacionNodo(posX, posY + elipse + coordenadasY);
            }

            if ((izquierdo != null) && (derecho != null))
            {
                posX += coordenadasX;
            }

            if (derecho != null)
            {
                derecho.UbicacionNodo(posX, posY + elipse + coordenadasY);

            }

            if (izquierdo != null && derecho != null)
            {
                coordenadasXderecho = Convert.ToInt32((izquierdo.coordenadasXderecho + derecho.coordenadasXderecho) / 2);

            }
            else if (izquierdo != null)
            {
                aux1 = izquierdo.coordenadasXderecho;
                izquierdo.coordenadasXderecho = coordenadasXderecho - 80;
                coordenadasXderecho = aux1;
            }
            else if (derecho != null)
            {
                aux2 = derecho.coordenadasXderecho;
                derecho.coordenadasXderecho = coordenadasXderecho + 80;
                coordenadasXderecho = aux2;

            }
            else
            {
                coordenadasXderecho = Convert.ToInt32(posX + elipse / 2);
                posX += elipse;
            }
        }
        #endregion

        #region Dibujar ramas
        public void DibujarRamas(Graphics grafico, Pen relacion)
        {
            if (izquierdo != null)
            {
                grafico.DrawLine(relacion, coordenadasXderecho, coordenadasYderecho, izquierdo.coordenadasXderecho, izquierdo.coordenadasYderecho);
                izquierdo.DibujarRamas(grafico, relacion);
            }

            if (derecho != null)
            {
                grafico.DrawLine(relacion, coordenadasXderecho, coordenadasYderecho, derecho.coordenadasXderecho, derecho.coordenadasYderecho);
                derecho.DibujarRamas(grafico, relacion);
            }
        }
        #endregion

        #region Dibujar nodos
        public void DibujarNodo(Graphics grafico, Font fuente, Brush color, Brush colorFuente, Pen relacion, Brush B)
        {
            Rectangle temp = new Rectangle(Convert.ToInt32(coordenadasXderecho - elipse / 2), Convert.ToInt32(coordenadasYderecho - elipse / 2), elipse, elipse);

            grafico.FillEllipse(B, temp);
            grafico.FillEllipse(color, temp);
            grafico.DrawEllipse(relacion, temp);
            grafico.FillEllipse(color, temp);
            grafico.DrawEllipse(relacion, temp);

            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;

            grafico.DrawString(notaFinal.ToString(), fuente, colorFuente, coordenadasXderecho, coordenadasYderecho, formato);

            if (izquierdo != null)
            {
                izquierdo.DibujarNodo(grafico, fuente, color, colorFuente, relacion, B);

            }
            if (derecho != null)
            {
                derecho.DibujarNodo(grafico, fuente, color, colorFuente, relacion, B);
            }
        }
        #endregion
    }
}
