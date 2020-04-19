using ProgrammingParadigms_BLL.DTO;
using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Implementation
{
    public class Lab3_BL : ILab3_BL
    {
        private AutomatDTO automat;
        private int length;

        public async Task<string> GetResultAsync(AutomatDTO automat, int length)
        {
            return await Task.Run(() => GetResult(automat, length));
        }

        public string GetResult(AutomatDTO automat, int length)
        {
            this.automat = automat;
            this.length = length;

            string res = FindResult();

            return res;
        }

        private string FindResult()
        {
            int startState = automat.StartState;
            string words = string.Empty;
            int currentLegth = 0;

            string result = RecurseFinder(startState, currentLegth, words);

            if(result.EndsWith(", "))
            {
                result = result.Remove(result.Length - 2);
            }

            return result;
        }

        private string RecurseFinder(int state, int currentLegth, string words)
        {
            if (currentLegth >= length)
            {
                if (automat.FinalStates.Contains(state))
                {
                    return words+", ";
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                var transition = automat.Transitions.Where(x => x.prevState == state);
                string res = string.Empty;

                foreach(var t in transition)
                {
                    res+=RecurseFinder(t.nextState, currentLegth + 1, words + t.symbol);
                }

                return res;
            }
        }
    }
}
