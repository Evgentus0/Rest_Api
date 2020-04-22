using ProgrammingParadigms_BLL.DTO;
using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Implementation
{
    public class Lab4_BL : ILab4_BL
    {
        private const string epsilon = "e";

        GrammarDTO _grammar;

        public async Task<bool> CheckForLL1Async(GrammarDTO grammar)
        {
            return await Task.Run(() => CheckForLL1(grammar));
        }
        public bool CheckForLL1(GrammarDTO grammar)
        {
            _grammar = grammar;

            bool isLL1 = true;

            foreach(var t in _grammar.NonTerminals)
            {
                isLL1 = CheckLL1ForNonTerminal(t);

                if (!isLL1)
                {
                    return isLL1;
                }
            }
            return isLL1;
        }

        public Task<(string first, string follow, bool isLL1)> CheckForLL1WithDetailsAsync(GrammarDTO grammar)
        {
            throw new NotImplementedException();
        }
        public (string first, string follow, bool isLL1) CheckForLL1WithDetails(GrammarDTO grammar)
        {
            throw new NotImplementedException();
        }


        bool CheckLL1ForNonTerminal(string nonTerminal)
        {
            if (IsEpsNonTerminal(nonTerminal))
            {
                int length = GetFirstForNonTerminal(nonTerminal).Intersect(GetFollow(nonTerminal)).Count();
                if (length > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                var rules = _grammar.Rules.Where(x => x.LeftPart == nonTerminal).Select(x => x.RightPart);
                var firsts = new List<string>();

                foreach(var r in rules)
                {
                    firsts.AddRange(GetFirstForRule(r));
                }

                return firsts.Count() == firsts.Distinct().Count();
            }
        }


        private IEnumerable<string> GetFirstForNonTerminal(string nonTerminal)
        {
            var res = GetFirstForNonTerminal(nonTerminal, new List<string>()).Where(x => x != epsilon).Distinct().ToList();

            if (IsEpsNonTerminal(nonTerminal))
            {
                res.Add(epsilon);
            }

            return res;
        }
        private IEnumerable<string> GetFirstForNonTerminal(string nonTerminal, ICollection<string> checkedNonTerminals)
        {
            List<string> result = new List<string>();

            checkedNonTerminals.Add(nonTerminal);

            var rules = _grammar.Rules.Where(x => x.LeftPart == nonTerminal).Select(x => x.RightPart);

            foreach (var r in rules)
            {
                result.AddRange(GetFirstForRule(r));
            }

            return result;
        }

        private IEnumerable<string> GetFirstForRule(string nonTerminals)
        {
            var res = GetFirstForRule(nonTerminals, new List<string>()).Where(x => x != epsilon).Distinct().ToList();

            if (IsEspRule(nonTerminals))
            {
                res.Add(epsilon);
            }

            return res;
        }
        private IEnumerable<string> GetFirstForRule(string nonTerminals, ICollection<string> checkedNonTerminals)
        {
            List<string> result = new List<string>();

            foreach (var r in nonTerminals)
            {
                if (_grammar.NonTerminals.Contains(r.ToString()))
                {
                    if (checkedNonTerminals.Contains(r.ToString()))
                    {
                        if (IsEpsNonTerminal(r.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else
                    {
                        result.AddRange(GetFirstForNonTerminal(r.ToString()));
                        if (!IsEpsNonTerminal(r.ToString()))
                        {
                            return result;
                        }
                    }
                }
                else
                {
                    result.Add(r.ToString());
                    return result;
                }
            }
            return result;
        }


        private IEnumerable<string> GetFollow(string nonTerminal)
        {
            var res = GetFollow(nonTerminal, new List<string>()).Where(x => x != epsilon).Distinct();
            return res;
        }
        private IEnumerable<string> GetFollow(string nonTerminal, ICollection<string> checkedNonTerminals)
        {
            List<string> result = new List<string>();
            var rules = _grammar.Rules.Where(x => x.RightPart.Contains(nonTerminal));
            checkedNonTerminals.Add(nonTerminal);

            foreach (var r in rules)
            {
                result.AddRange(GetFollowInRule(nonTerminal, r, checkedNonTerminals));
            }

            return result;
        }
        private IEnumerable<string> GetFollowInRule(string nonTerminal, Rule rule, ICollection<string> checkedNonTerminals)
        {
            List<string> result = new List<string>();

            string rightPart = rule.RightPart;
            int legnth = rightPart.Length;
            List<int> indexes = new List<int>();

            for (int i = 0; i < legnth; i++)
            {
                if (rightPart[i].ToString() == nonTerminal)
                {
                    indexes.Add(i);
                }
            }

            foreach (var i in indexes)
            {
                bool addEndRowSymbol = true; ;
                for (int j = i + 1; j < legnth; j++)
                {
                    if (_grammar.NonTerminals.Contains(rightPart[j].ToString()))
                    {
                        if (IsEpsNonTerminal(rightPart[j].ToString()))
                        {
                            result.AddRange(GetFirstForNonTerminal(rightPart[j].ToString()));
                        }
                        else
                        {
                            result.AddRange(GetFirstForNonTerminal(rightPart[j].ToString()));
                            addEndRowSymbol = false;
                            break;
                        }
                    }
                    else
                    {
                        result.Add(rightPart[j].ToString());
                        addEndRowSymbol = false;
                        break;
                    }
                }
                if (addEndRowSymbol)
                {
                    result.Add("$");
                    if (!checkedNonTerminals.Contains(rule.LeftPart))
                    {
                        result.AddRange(GetFollow(rule.LeftPart, checkedNonTerminals));
                    }
                }
            }
            return result;
        }

        private bool IsEpsNonTerminal(string nonTerminal)
        {
            return IsEpsNonTerminal(nonTerminal, new List<string>());
        }
        private bool IsEpsNonTerminal(string nonTerminal, ICollection<string> checkedNonTerminals)
        {
            var rules = _grammar.Rules.Where(x => x.LeftPart == nonTerminal).Select(x=>x.RightPart);

            checkedNonTerminals.Add(nonTerminal);
            foreach(var r in rules)
            {
                var res = IsEspRule(r, checkedNonTerminals);
                if (res == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsEspRule(string rule)
        {
            return IsEspRule(rule, new List<string>());
        }
        private bool IsEspRule(string rule, ICollection<string> checkedNonTerminals)
        {
            foreach(var r in rule)
            {
                bool res;
                if (_grammar.NonTerminals.Contains(r.ToString()))
                {
                    if (checkedNonTerminals.Contains(r.ToString()))
                    {
                        res = false;
                    }
                    else
                    {
                        res = IsEpsNonTerminal(r.ToString(), checkedNonTerminals);
                    }
                }
                else
                {
                    if(r.ToString() == epsilon)
                    {
                        res = true; 
                    }
                    else
                    {
                        res = false;
                    }
                }
                if (!res)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
