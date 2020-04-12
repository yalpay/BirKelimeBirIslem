using BirKelimeBirIslemClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslemClassLibrary.Generators
{
    public class CalculationGenerator
    {
        private static Random rnd = new Random();
        public static int[] GenerateStandardInput()
        {
            int[] input = new int[6];
            for (int i = 0; i < 5; i++)
            {
                input[i] = rnd.Next(1, 10);
            }
            input[5] = rnd.Next(5, 20) * 5;
            return input;
        }
        public static int GenerateStandardTarget()
        {
            return rnd.Next(200, 1000);
        }
        public static Calculation GenerateStandardIslem()
        {
            Calculation calc = new Calculation();
            calc.Input = GenerateStandardInput();
            calc.Target = GenerateStandardTarget();

            return calc;
        }
    }
}
