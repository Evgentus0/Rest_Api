using ProgrammingParadigms_BLL.DTO;
using ProgrmmingParadigms.Models;
using System;
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


        public Grammar GetGrammarModel(GrammarDTO grammar)
        {
            var nonTerminals = grammar.NonTerminals;
            var terminals = grammar.Terminals;

            var rules = grammar.Rules.Select(x => new Rule() { LeftPart = x.LeftPart, RightPart = x.RightPart });

            return new Grammar()
            {
                NonTerminals = nonTerminals,
                Terminals = terminals,
                Rules = rules
            };
        }

        public GrammarDTO GetGrammarDTO(Grammar grammar)
        {
            var nonTerminals = grammar.NonTerminals.Select(x=>x.Trim());
            var terminals = grammar.Terminals.Select(x => x.Trim());

            var rules = grammar.Rules.Select(x => new RuleDTO() { LeftPart = x.LeftPart.Trim(), RightPart = x.RightPart.Trim() });

            return new GrammarDTO()
            {
                NonTerminals = nonTerminals,
                Terminals = terminals,
                Rules = rules
            };
        }

        internal Lab4 GetLab4((List<(string nonTerminal, List<string> firsts, string follow)> details, bool isLL1) data)
        {
            List<Details> details = new List<Details>();

            foreach(var d in data.details)
            {
                details.Add(new Details()
                {
                    Firsts = d.firsts,
                    Follow = d.follow,
                    NonTerminal = d.nonTerminal
                });
            }

            Lab4 res = new Lab4()
            {
                Details = details,
                IsLL1 = data.isLL1
            };

            return res;
        }
    }
}
