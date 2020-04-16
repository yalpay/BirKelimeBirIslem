using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BirKelimeBirIslem.Processors;
using BirKelimeBirIslemClassLibrary.Classes;
using BirKelimeBirIslemClassLibrary.Generators;
using BirKelimeBirIslemClassLibrary.Processors;

namespace IslemTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate();
            Console.ReadLine();
        }

        public static void Calculate()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            Calculation calc = CalculationGenerator.GenerateStandardIslem();
            //calc = new Calculation
            //{
            //    Input = new int[] { 2, 8, 7, 5, 25, 10 },
            //    Target = 777
            //};
           
            //Printers.PrintSolution(solution);
            //Printers.PrintInput(calc);
            CalculationProcessor.Solve(calc);
            Printers.PrintSolutions(calc);
            //Solution solution = SolutionProcessor.CraziestSolution(calc);
            //Printers.PrintSolution(solution);
            //Console.WriteLine($"Target {calc.Target} have no solution!\n");        
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            _ = calc;
        }
    }
}
