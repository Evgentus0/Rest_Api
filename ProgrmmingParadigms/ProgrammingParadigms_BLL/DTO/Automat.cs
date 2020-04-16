using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingParadigms_BLL.DTO
{
    public class Automat
    {
        public List<int> States { get; private set; }
        public List<Transition> Transitions { get; private set; }
        public int StartState { get; private set; }
        public List<int> FinalStates { get; private set; }

        public Automat(List<int> states, List<Transition> transitions, int startState, List<int> finalStates)
        {
            States = states;
            Transitions = transitions;
            StartState = startState;
            FinalStates = finalStates;
        }
    }

    public struct Transition
    {
        public int prevState;
        public int nextState;
        public char symbol;
        public Transition(int prevState, char symbol, int nextState)
        {
            this.prevState = prevState;
            this.nextState = nextState;
            this.symbol = symbol;
        }
    }
}
