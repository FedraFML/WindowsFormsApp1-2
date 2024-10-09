using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1.algoritmo
{
    public class AlgoritmoSimulacion
    {
        public AlgoritmoSimulacion() { }

        // Método para generar una mezcla de valores aleatorios y valores basados en la fórmula
        public List<int> GenerarValores(int valorMinimo, int valorMaximo, int valorMuestra)
        {
            List<int> listaEnteros = new List<int>();
            Random random = new Random();

            for (int i = 0; i < valorMuestra; i++)
            {
                if (i % 2 == 0) 
                {
                    int valorCalculado = 5 * (i + 1);
                    if (valorCalculado >= valorMinimo && valorCalculado <= valorMaximo)
                    {
                        listaEnteros.Add(valorCalculado);
                    }
                }
                else // Cada valor en posición impar es aleatorio
                {
                    int valorAleatorio = random.Next(valorMinimo, valorMaximo + 1);
                    listaEnteros.Add(valorAleatorio);
                }
            }

            return listaEnteros; // Retorna la lista de valores generados
        }
    }
}
