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
        private static int[] _frenchInputSmalls = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10 };
        private static int[] _frenchInputBigs = new int[] { 25, 50, 75, 100 };
        public const int FrenchInputLength = 6;

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
        public static int[] GenerateFrenchInput()
        {
            int[] input = new int[FrenchInputLength];
            int bigCount = rnd.Next(_frenchInputBigs.Length) + 1;

            for (int i = bigCount; i < FrenchInputLength; i++)            
                input[i] = _frenchInputSmalls[rnd.Next(_frenchInputSmalls.Length)];
            while (bigCount > 0)            
                input[--bigCount] = _frenchInputBigs[rnd.Next(_frenchInputBigs.Length)];                        
            
            return input;
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
