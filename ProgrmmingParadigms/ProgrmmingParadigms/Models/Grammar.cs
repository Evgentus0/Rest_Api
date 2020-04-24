using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrmmingParadigms.Models
{
    public class Grammar
    {
        public IEnumerable<string> NonTerminals { get; set; }
        public IEnumerable<string> Terminals { get; set; }
        public IEnumerable<Rule> Rules { get; set; }
    }

    public class Rule
    {
        public string LeftPart { get; set; }
        public string RightPart { get; set; }

        public override string ToString()
        {
            return $"{LeftPart} -> {RightPart}";
        }
    }

}
