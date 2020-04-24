using NUnit.Framework;
using ProgrammingParadigms_BLL.DTO;
using ProgrammingParadigms_BLL.Implementation;
using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class Laba4
    {
        ILab4_BL _worker;

        [SetUp]
        public void Setup()
        {
            _worker = new Lab4_BL();
        }

        [Test]
        public void Test1()
        {
            string t = " S   ";
            t = t.Trim();


            //arrange
            List<string> nonTerminals = new List<string>()
            {
                "S", "X", "Y"
            };

            List<string> terminals = new List<string>()
            {
                "a", "b", "d"
            };

            List<RuleDTO> rules = new List<RuleDTO>()
            {
                new RuleDTO(){LeftPart = "S", RightPart="X"},
                new RuleDTO(){LeftPart = "S", RightPart = "Y"},
                new RuleDTO(){LeftPart = "X", RightPart = "aXab"},
                new RuleDTO(){LeftPart = "X", RightPart = "ab"},
                new RuleDTO(){LeftPart = "Y", RightPart = "aYd"},
                new RuleDTO(){LeftPart = "Y", RightPart = "b"},
            };

            GrammarDTO grammar = new GrammarDTO()
            {
                NonTerminals = nonTerminals,
                Terminals = terminals,
                Rules = rules
            };

            //act
            bool res = _worker.CheckForLL1(grammar);

            //assert
            Assert.AreEqual(res, false);
        }

        [Test]
        public void Test2()
        {
            //arrange
            List<string> nonTerminals = new List<string>()
            {
                "S", "T", "K", "M", "L"
            };

            List<string> terminals = new List<string>()
            {
                "+", "*", "(", ")", "c"
            };

            List<RuleDTO> rules = new List<RuleDTO>()
            {
                new RuleDTO(){LeftPart = "S", RightPart="TK"},
                new RuleDTO(){LeftPart = "K", RightPart = "+TK"},
                new RuleDTO(){LeftPart = "K", RightPart = "e"},
                new RuleDTO(){LeftPart = "T", RightPart = "ML"},
                new RuleDTO(){LeftPart = "L", RightPart = "*MT"},
                new RuleDTO(){LeftPart = "L", RightPart = "e"},
                new RuleDTO(){LeftPart = "M", RightPart = "(S)"},
                new RuleDTO(){LeftPart = "M", RightPart = "c"},
            };

            GrammarDTO grammar = new GrammarDTO()
            {
                NonTerminals = nonTerminals,
                Terminals = terminals,
                Rules = rules
            };

            //act
            bool res = _worker.CheckForLL1(grammar);

            //assert
            Assert.AreEqual(res, true);
        }

        [Test]
        public void Test2WithDetails()
        {
            //arrange
            List<string> nonTerminals = new List<string>()
            {
                "S", "T", "K", "M", "L"
            };

            List<string> terminals = new List<string>()
            {
                "+", "*", "(", ")", "c"
            };

            List<RuleDTO> rules = new List<RuleDTO>()
            {
                new RuleDTO(){LeftPart = "S", RightPart="TK"},
                new RuleDTO(){LeftPart = "K", RightPart = "+TK"},
                new RuleDTO(){LeftPart = "K", RightPart = "e"},
                new RuleDTO(){LeftPart = "T", RightPart = "ML"},
                new RuleDTO(){LeftPart = "L", RightPart = "*MT"},
                new RuleDTO(){LeftPart = "L", RightPart = "e"},
                new RuleDTO(){LeftPart = "M", RightPart = "(S)"},
                new RuleDTO(){LeftPart = "M", RightPart = "c"},
            };

            GrammarDTO grammar = new GrammarDTO()
            {
                NonTerminals = nonTerminals,
                Terminals = terminals,
                Rules = rules
            };

            //act
            var res = _worker.CheckForLL1WithDetails(grammar);

            //assert
            Assert.AreEqual(res.isLL1, true);

            Assert.AreEqual(res.details[0].nonTerminal, "S");
            Assert.AreEqual(res.details[0].firsts[0].OrderBy(x=>x), "(c");
            Assert.AreEqual(res.details[0].follow.OrderBy(x => x), ")");
        }
    }
}
