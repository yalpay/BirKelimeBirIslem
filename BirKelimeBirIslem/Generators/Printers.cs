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
            Console.WriteLine($"Input: {String.Join(", ", calc.Input)}");
            Console.WriteLine($"Target: {calc.Target}");
        }
        public static void PrintSolutions(Calculation calc)
        {
            calc.AllSolution.ForEach(solution => Console.WriteLine($"{solution.Process}\n\n---------------\n"));
            Console.WriteLine($"Number of solutions: {calc.AllSolution.Count}");
        }
    }
}
