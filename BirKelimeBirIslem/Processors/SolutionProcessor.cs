using BirKelimeBirIslemClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirKelimeBirIslem.Processors
{
    public static class SolutionProcessor
    {
        public static Solution CraziestSolution(Calculation calc)
        {
            if (calc.AllSolutions.Count == 0)
            {
                //Console.WriteLine("No solution found to this problem!");
                return null;
            }
            // to be implemented
            Solution solutionWithMaxNumber = calc.AllSolutions.Last();
            // to be implemented
            return solutionWithMaxNumber;
        }
    }
}
