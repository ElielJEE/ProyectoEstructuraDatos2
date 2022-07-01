using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuraDatos2_Eliel_Escobar
{
    class CCaminoCorto
    {
        public string AlgoritmoFloyd(long[,] AMY, int numero)
        {
            int vertices = numero;
            long[,] matrizAbyasencia = AMY;
            string[,] caminos = new string[vertices, vertices];
            string[,] caminosAuxiliares = new string[vertices, vertices];
            string caminoRecorrido = "", cadena = "", caminitos = "";
            int i, j, k;
            float temporal1, temporal2, temporal3, temporal4, minimo;

            for (i = 0; i < vertices; i++)
            {
                for (j = 0; j < vertices; j++)
                {
                    caminos[i, j] = "";
                    caminosAuxiliares[i, j] = "";
                }
            }

            for (k = 0; k < vertices; k++)
            {
                for (i = 0; i < vertices; i++)
                {
                    for (j = 0; j < vertices; j++)
                    {
                        temporal1 = matrizAbyasencia[i, j];
                        temporal2 = matrizAbyasencia[i, k];
                        temporal3 = matrizAbyasencia[k, j];
                        temporal4 = temporal2 + temporal3;

                        minimo = Math.Min(temporal1, temporal4);

                        if (temporal1 != temporal4)
                        {
                            if (minimo == temporal4)
                            {
                                caminoRecorrido = "";
                                caminosAuxiliares[i, j] = k + "";
                                caminos[i, j] = CaminoR(i, k, caminosAuxiliares, caminoRecorrido) + (k + 1);
                            }
                        }
                        matrizAbyasencia[i, j] = (long)minimo;
                    }
                }
            }

            for (i = 0; i < vertices; i++)
            {
                for (j = 0; j < vertices; j++)
                {
                    cadena = cadena + "[" + matrizAbyasencia[i, j] + "]";
                }
                cadena = cadena + "\n";
            }

            for (i = 0; i < vertices; i++)
            {
                for (j = 0; j < vertices; j++)
                {
                    if (matrizAbyasencia[i, j] != 1000000000)
                    {
                        if (i != j)
                        {
                            if (caminos[i, j].Equals(""))
                            {
                                caminitos += "De (" + (i + 1) + "------>" + (j + 1) + ") " +
                                    "irse por (" + (i + 1) + ",   " + (j + 1) + ")\n";
                            }
                            else
                            {
                                caminitos += "De (" + (i + 1) + "------>" + (j + 1) + ") " +
                                    "irse por (" + (i + 1) + ",   " + caminos[i, j] + ", " + (j + 1) + ")\n";
                            }
                        }
                    }
                }
            }
            return "La matriz de caminos mas cortos entre los diferentes vertices es: \n" + cadena +
                "\nlos diferentes caminos mas cortos entre vertices son: \n" + caminitos;
        }

        public string CaminoR(int i, int k, string[,] caminosAux, string caminoRecorrido)
        {
            if (caminosAux[i, k].Equals(""))
            {
                return "";
            }
            else
            {
                caminoRecorrido += CaminoR(i, int.Parse(caminosAux[i, k]), caminosAux, caminoRecorrido) +
                    (int.Parse(caminosAux[i, k]) + 1) + ",  ";
                return caminoRecorrido;
            }
        }
    }
}
