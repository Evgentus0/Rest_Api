using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrmmingParadigms.Models
{
    public class Lab4
    {
        public List<Details> Details { get; set; }
        public bool IsLL1 { get; set; }
    }

    public class Details
    {
        public string NonTerminal { get; set; }
        public List<string> Firsts { get; set; }
        public string Follow { get; set; }
    }
}
