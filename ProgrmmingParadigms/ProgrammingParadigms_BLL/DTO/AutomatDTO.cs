using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingParadigms_BLL.DTO
{
    public class AutomatDTO
    {
        public List<int> States { get; private set; }
        public List<TransitionDTO> Transitions { get; private set; }
        public int StartState { get; private set; }
        public List<int> FinalStates { get; private set; }

        public AutomatDTO(List<int> states, List<TransitionDTO> transitions, int startState, List<int> finalStates)
        {
            States = states;
            Transitions = transitions;
            StartState = startState;
            FinalStates = finalStates;
        }
    }

    public struct TransitionDTO
    {
        public int prevState;
        public int nextState;
        public char symbol;
        public TransitionDTO(int prevState, char symbol, int nextState)
        {
            this.prevState = prevState;
            this.nextState = nextState;
            this.symbol = symbol;
        }
    }
}
