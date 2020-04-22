using NUnit.Framework;
using ProgrammingParadigms_BLL.DTO;
using ProgrammingParadigms_BLL.Implementation;
using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
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
            //arrange
            List<string> nonTerminals = new List<string>()
            {
                "S", "X", "Y"
            };

            List<string> terminals = new List<string>()
            {
                "a", "b", "d"
            };

            List<Rule> rules = new List<Rule>()
            {
                new Rule(){LeftPart = "S", RightPart="X"},
                new Rule(){LeftPart = "S", RightPart = "Y"},
                new Rule(){LeftPart = "X", RightPart = "aXab"},
                new Rule(){LeftPart = "X", RightPart = "ab"},
                new Rule(){LeftPart = "Y", RightPart = "aYd"},
                new Rule(){LeftPart = "Y", RightPart = "b"},
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

            List<Rule> rules = new List<Rule>()
            {
                new Rule(){LeftPart = "S", RightPart="TK"},
                new Rule(){LeftPart = "K", RightPart = "+TK"},
                new Rule(){LeftPart = "K", RightPart = "e"},
                new Rule(){LeftPart = "T", RightPart = "ML"},
                new Rule(){LeftPart = "L", RightPart = "*MT"},
                new Rule(){LeftPart = "L", RightPart = "e"},
                new Rule(){LeftPart = "M", RightPart = "(S)"},
                new Rule(){LeftPart = "M", RightPart = "c"},
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
    }
}
