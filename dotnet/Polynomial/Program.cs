// See https://aka.ms/new-console-template for more information
using System;

namespace Lista5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj współczynnik a:");
            string? a = Console.ReadLine();
            Console.WriteLine("Podaj współczynnik b:");
            string? b = Console.ReadLine();
            Console.WriteLine("Podaj współczynnik c:");
            string? c = Console.ReadLine();
            if (a == "0")
            {
                Console.WriteLine("To nie jest funkcja kwadratowa");
            }
            else
            {
                double[] listOfSolutions = isThereAnyX(Convert.ToDouble(a), Convert.ToDouble(b), Convert.ToDouble(c));
                if (listOfSolutions.Length == 0) {
                    Console.WriteLine("Brak rozwiązań.");
                } else if(listOfSolutions.Length == 1)
                {
                    Console.WriteLine("Jedno rozwiązanie: {0}", listOfSolutions[0]);
                } else
                {
                    Console.WriteLine($"Dwa rozwiązania: {listOfSolutions[0]:0.00} i {listOfSolutions[1]:0.00}");
                }
            }
            
            
        }

        static double[] isThereAnyX(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            
            if (delta < 0 )
            {
                return new double[0];
            } else if (delta > 0)
            {
                double[] rozwiazania = new double[2];
                double pierw = Math.Sqrt(delta);
                double x1 = ((-1 * b) - pierw) / (2 * a);
                double x2 = ((-1 * b) + pierw) / (2 * a);
                rozwiazania[0] = x1;
                rozwiazania[1] = x2;
                return rozwiazania;
            } else
            {
                double[] rozwiazania = new double[1];
                double x0 = (-1 * b) / (2 * a);
                rozwiazania[0] = x0;
                return rozwiazania;
            }
                
        }
    }
}
