using BirKelimeBirIslemClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslemClassLibrary.Processors
{
    public static class CalculationProcessor
    {
        //private static bool solutionFound;
        //private static long counter = 0;        
        public static void Solve(Calculation calc)
        {
            if (calc.Input.Length == 1)
                return;

            CheckDirectSolution(calc);
            var operations = new List<string>() { "+", "-", "*", "/" };
            operations.ForEach(operation => Process(calc, operation));           

        }
        public static void CheckDirectSolution(Calculation calc)
        {
            for (int j = 0; j < calc.Input.Length; j++)
            {
                for (int i = j + 1; i < calc.Input.Length; i++)
                {
                    int mx = Math.Max(calc.Input[i], calc.Input[j]);
                    int mn = Math.Min(calc.Input[i], calc.Input[j]);

                    if (mx + mn == calc.Target)
                        AddSolution(calc, $"{mx} + {mn}");
                    if (mx - mn == calc.Target)
                        AddSolution(calc, $"{mx} - {mn}");
                    if (mx * mn == calc.Target)
                        AddSolution(calc, $"{mx} * {mn}");
                    if (mx % mn == 0 && mx / mn == calc.Target)
                        AddSolution(calc, $"{mx} / {mn}");
                }
            }
        }
        private static void AddSolution(Calculation calc, string operation)
        {
            calc.CurrentSolution.Operations.Add(operation);
            calc.CurrentSolution.Process.Append($"\n{operation}\n{calc.Target}");
            bool operatnComparison = !calc.AllSolutions.Any(soln => soln.Operations.All(calc.CurrentSolution.Operations.Contains) &&
                                                                   soln.Operations.Count == calc.CurrentSolution.Operations.Count);
            if (operatnComparison)
                calc.AllSolutions.Add(calc.CurrentSolution);
        }
        private static void Process(Calculation calc, string operation)
        {
            //counter++;
            int[] newList = new int[calc.Input.Length - 1];
            for (int i = 0; i < calc.Input.Length; i++)
            {
                for (int j = i + 1; j < calc.Input.Length; j++)
                {
                    int mx = Math.Max(calc.Input[i], calc.Input[j]);
                    int mn = Math.Min(calc.Input[i], calc.Input[j]);

                    // no need to subtract if the two elements are equal
                    bool unnecessarySubtract = mx == mn && operation == "-";
                    if (unnecessarySubtract)
                        continue;

                    // no enhancement by multiplying an element with 1
                    bool unnecessaryMultiply = mn == 1 && operation == "*";
                    if (unnecessaryMultiply)
                        continue;

                    // no enhancement by dividing an element to 1, division should be perfect
                    bool illegalDivide = operation == "/" && (mx % mn != 0 || mn == 1);
                    if (illegalDivide)
                        continue;

                    // creating the array from existing input by making operation between input[i] and input[j] 
                    // example: let input = 1, 2, 3, 4, 5;  i = 1; j = 3;  =>  newList would be: 1, 6, 3, 5 
                    int index = 0;
                    bool rightOfJ = false;
                    while (index < newList.Length)
                    {
                        if (rightOfJ == false)
                        {
                            if (index == i)
                            {
                                if (operation == "+")
                                    newList[index] = mx + mn;
                                if (operation == "-")
                                    newList[index] = mx - mn;
                                if (operation == "*")
                                    newList[index] = mx * mn;
                                if (operation == "/" && mx % mn == 0)
                                    newList[index] = mx / mn;
                            }
                            else
                                newList[index] = calc.Input[index];
                            if (index == j - 1)
                                rightOfJ = true;
                        }
                        else
                            newList[index] = calc.Input[index + 1];

                        index++;
                    }

                    // add current operation to solution and continue to search recursively
                    string list = String.Join(", ", newList.OrderBy(x => x));
                    string process = $"{ mx } { operation} { mn }";
                    string soln = $"{calc.CurrentSolution.Process}\n{process}\n{list}\n";
                    Solve(new Calculation()
                    {
                        Input = newList,
                        Target = calc.Target,
                        CurrentSolution = new Solution()
                        {
                            Operations = calc.CurrentSolution.Operations.Union(new List<string> { process }).ToList(),
                            Process = new StringBuilder(soln)
                        },
                        AllSolutions = calc.AllSolutions
                    });
                }
            }
        }

    }
}
