using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslemClassLibrary.Classes
{
    public class Solution
    {        
        public List<String> Operations { get; set; }
        public StringBuilder Process { get; set; }
        public bool SameWayDifferentElement { get; set; } = false;
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
