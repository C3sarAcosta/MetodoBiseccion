using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoBiseccion
{
    internal class Program
    {
        // Definir la función cuya raíz queremos encontrar
        static double Funcion(double x)
        {
            return (4*Math.Pow(x, 2)) - (5*x); // f(x) = x^3 - 4x - 10
        }

        // Método de bisección
        static double Biseccion(double a, double b, double tolerancia, int maxIteraciones)
        {
            // Verificar si hay un cambio de signo
            if (Funcion(a) * Funcion(b) > 0)
            {
                Console.WriteLine("La función debe tener signos opuestos en los extremos.");
                return double.NaN;
            }

            double c = a; // Inicializar c
            for (int i = 0; i < maxIteraciones; i++)
            {
                // Encontrar el punto medio
                c = (a + b) / 2;

                // Comprobar si c es la raíz
                if (Funcion(c) == 0.0)
                    break;

                // Determinar el subintervalo donde se encuentra la raíz
                if (Funcion(c) * Funcion(a) < 0)
                    b = c; // La raíz está en el intervalo [a, c]
                else
                    a = c; // La raíz está en el intervalo [c, b]

                // Comprobar si la tolerancia se ha alcanzado
                if (Math.Abs(Funcion(c)) < tolerancia)
                    break;
            }

            return c; // Retornar la raíz aproximada
        }

        static void Main(string[] args)
        {
            // Definir el intervalo [a, b]
            double a = 1; // Límite inferior
            double b = 1.6; // Límite superior
            double tolerancia = 0.000001; // Tolerancia para la solución
            int maxIteraciones = 100; // Número máximo de iteraciones

            // Llamar al método de bisección
            double raiz = Biseccion(a, b, tolerancia, maxIteraciones);

            // Mostrar el resultado
            if (!double.IsNaN(raiz))
            {
                Console.WriteLine($"La raíz aproximada es: {raiz}");
            }

            Console.ReadLine(); // Esperar a que el usuario presione una tecla
        }

    }
}