using ProgrammingParadigms_BLL.DTO;
using ProgrmmingParadigms.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProgrmmingParadigms.Helpers
{
    public class Mapper
    {

        public Automat GetAutomatModel(AutomatDTO dto)
        {
            List<int> states = new List<int>(dto.States);
            int startState = dto.StartState;
            List<int> finalStates = new List<int>(dto.FinalStates);
            List<Transition> transitions = GetTransitionModel(dto.Transitions);

            return new Automat() 
            { 
                States = states,
                FinalStates = finalStates,
                StartState = startState,
                Transitions = transitions
            };
        }

        private List<Transition> GetTransitionModel(List<TransitionDTO> dtos)
        {
            var list = new List<Transition>(dtos.Select(x => new Transition() { PrevState = x.prevState, Symbol = x.symbol.ToString(), NextState = x.nextState}));

            return list;
        }

        public AutomatDTO GetAutomatDTO(Automat model)
        {
            List<int> states = new List<int>(model.States);
            int startState = model.StartState;
            List<int> finalStates = new List<int>(model.FinalStates);
            List<TransitionDTO> transitions = GetTransitionDTO(model.Transitions);

            return new AutomatDTO(states, transitions, startState, finalStates);
        }

        private List<TransitionDTO> GetTransitionDTO(List<Transition> models)
        {
            var list = new List<TransitionDTO>(models.Select(x => new TransitionDTO(x.PrevState, x.Symbol.Where(x=>!char.IsWhiteSpace(x)).First(), x.NextState)));

            return list;
        }
    }
}
