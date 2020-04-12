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
        private static bool solutionFound;       
        
        public static void Solve(Calculation calc)
        {
            if (calc.Input.Length == 1)
                return;

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

            if (solutionFound == false && calc.Input.Length > 2)
            {
                int[] newDizi = new int[calc.Input.Length - 1];
                Process(calc, newDizi, "+");
                Process(calc, newDizi, "-");
                Process(calc, newDizi, "*");
                Process(calc, newDizi, "/");
            }
            solutionFound = false;
        }
        private static void AddSolution(Calculation calc, string operation)
        {
            calc.CurrentSolution.Operations.Add(operation);
            calc.CurrentSolution.Process.Append($"\n{operation}\n{calc.Target}");
            bool operatnComparison = !calc.AllSolution.Any(soln => soln.Operations.All(calc.CurrentSolution.Operations.Contains) &&
                                                                   soln.Operations.Count == calc.CurrentSolution.Operations.Count);
            if (operatnComparison)
                calc.AllSolution.Add(calc.CurrentSolution);
            else
                calc.CurrentSolution.SameWayDifferentElement = true;
                
            solutionFound = true;
        }
        private static void Process(Calculation calc, int[] newList, string operation)
        {
            for (int i = 0; i < calc.Input.Length; i++)
            {
                for (int j = i + 1; j < calc.Input.Length; j++)
                {
                    int mx = Math.Max(calc.Input[i], calc.Input[j]);
                    int mn = Math.Min(calc.Input[i], calc.Input[j]);

                    bool illegalSubtract = mx == mn && operation == "-";
                    if (illegalSubtract)                    
                        continue;   
                    
                    bool illegalMultiply = mn == 1 && operation == "*";
                    if (illegalMultiply)
                        continue;

                    bool illegalDivide = operation == "/" && (mx % mn != 0 || mn == 1);
                    if (illegalDivide)
                        continue;

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
                                if (operation == "/")
                                    if (mn != 0 && mx % mn == 0)
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
                        AllSolution = calc.AllSolution
                    });
                }
            }
        }        
    }
}
