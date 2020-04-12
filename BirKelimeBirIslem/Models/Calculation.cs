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
        public List<Solution> AllSolutions { get; set; }
        public Calculation()        
        {            
            CurrentSolution = new Solution();
            AllSolutions = new List<Solution>();
        }        
    }
}
