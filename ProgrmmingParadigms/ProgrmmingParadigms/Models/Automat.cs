using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrmmingParadigms.Models
{
    public class Automat
    {
        public List<int> States { get; set; }
        public List<Transition> Transitions { get; set; }
        public int StartState { get; set; }
        public List<int> FinalStates { get; set; }
    }

    public class Transition
    {
        public int PrevState { get; set; }
        public int NextState { get; set; }
        public string Symbol { get; set; }
    }
}
