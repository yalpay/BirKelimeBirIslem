using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslemClassLibrary.Classes
{
    public class Solution
    {     
        // solution steps like,  3 + 5,  4 * 8 etc.
        public List<String> Operations { get; set; }
        public StringBuilder Process { get; set; }        
        public Solution()
        {            
            Operations = new List<string>();
            Process = new StringBuilder();
        }
        public override string ToString()
        {
            return Process.ToString();
        }
    }
}
