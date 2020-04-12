using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirKelimeBirIslemClassLibrary.Classes
{
    public class Calculation
    {
        private int[] _input;
        public int[] Input {
            get { return _input; }
            set
            {          
                CurrentSolution.Process = new StringBuilder($"{String.Join(", ", value)}\n");
                _input = value;
            }
        }
        public int Target { get; set; }      
        public Solution CurrentSolution { get; set; }
        public List<Solution> AllSolution { get; set; }
        public Calculation()        
        {            
            CurrentSolution = new Solution();
            AllSolution = new List<Solution>();
        }
        public Solution CraziestSolution()
        {
            if (AllSolution.Count == 0)
            {
                Console.WriteLine("No solution found to this problem!");
                return null;
            }

            var solutions = AllSolution.SelectMany(soln => soln.Operations.Select(oprn => 
            new { num = oprn.Substring(0, oprn.IndexOf(" ")), index = soln }));            
            var solutionWithMaxNumber = solutions.OrderByDescending(soln => soln.num).First().index;            
            return solutionWithMaxNumber;
        }
    }
}
