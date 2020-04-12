using System;
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
            var dt = DateTime.Now;
            Calculation calc = CalculationGenerator.GenerateStandardIslem();

            calc = new Calculation
            {
                Input = new int[] { 1, 2, 5, 7, 8, 75 },
                Target = 954
            };

            //for (int i = 0; i < 20; i++)
            //{
            //    dt = DateTime.Now;
            //    calc = CalculationGenerator.GenerateStandardIslem();
            //    Printers.PrintInput(calc);
            //    CalculationProcessor.Solve(calc);
            //    //Printers.PrintSolutions(calc);
            //    Solution soln = CalculationProcessor.CraziestSolution(calc);
            //    Printers.PrintSolution(soln);
            //    Console.WriteLine((DateTime.Now - dt).TotalSeconds);
            //}

            Printers.PrintInput(calc);
            CalculationProcessor.Solve(calc);
            Printers.PrintSolutions(calc);
            //Solution solution = CalculationProcessor.CraziestSolution(calc);
            //Printers.PrintSolution(solution);
            Console.WriteLine();
            Console.WriteLine((DateTime.Now - dt).TotalSeconds);
        }
    }
}
