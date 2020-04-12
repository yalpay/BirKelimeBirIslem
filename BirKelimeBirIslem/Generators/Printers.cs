using BirKelimeBirIslemClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslemClassLibrary.Generators
{
    public static class Printers
    {
        public static void PrintInput(Calculation calc)
        {
            Console.WriteLine($"\nInput: {String.Join(", ", calc.Input)}");
            Console.WriteLine($"Target: {calc.Target}");
        }
        public static void PrintSolutions(Calculation calc)
        {
            calc.AllSolutions.ForEach(solution => Console.WriteLine($"{solution.Process}\n\n---------------\n"));
            Console.WriteLine($"Number of solutions: {calc.AllSolutions.Count}");
        }

        public static void PrintSolution(Solution solution)
        {
            Console.WriteLine();
            Console.WriteLine(solution.Process);
        }
    }
}
