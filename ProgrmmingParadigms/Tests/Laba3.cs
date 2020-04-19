using NUnit.Framework;
using ProgrammingParadigms_BLL.DTO;
using ProgrammingParadigms_BLL.Implementation;
using ProgrammingParadigms_BLL.Interfaces;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        ILab3_BL _worker;

        [SetUp]
        public void Setup()
        {
            _worker = new Lab3_BL();
        }

        [Test]
        [TestCase(3, "aba, bab")]
        [TestCase(4, "abba, baab")]
        public void Test1(int length, string expectedString)
        {
            //arrange
            List<int> states = new List<int>() { 1, 2, 3, 4 };
            int startState = 1;
            List<int> finalStates = new List<int>() { 4 };
            List<TransitionDTO> transitions = new List<TransitionDTO>()
            {
                new TransitionDTO(1, 'a', 2),
                new TransitionDTO(1, 'b', 3),
                new TransitionDTO(2, 'a', 4),
                new TransitionDTO(2, 'b', 2),
                new TransitionDTO(3, 'b', 4),
                new TransitionDTO(3, 'a', 3)
            };
            AutomatDTO automat = new AutomatDTO(states, transitions, startState, finalStates);

            //act
            string res = _worker.GetResult(automat, length);

            //assert
            Assert.AreEqual(res, expectedString);
        }

        [Test]
        [TestCase(4, "aaaa, aaab, aaba, aabb, abaa, abab, abba, bbaa, bbab, bbba, bbbb, baba, babb, baab")]
        [TestCase(7, "aaaaaaa, aaaaaab, aaaaaba, aaaaabb, aaaabaa, aaaabab, aaaabba, aaaabbb, aaabaaa, aaabaab," +
            " aaababa, aaababb, aaabbaa, aaabbab, aaabbba, aaabbbb, aabaaaa, aabaaab, aabaaba, aabaabb, aababaa, " +
            "aababab, aababba, aababbb, aabbaaa, aabbaab, aabbaba, aabbabb, aabbbaa, aabbbab, aabbbba, aabbbbb, " +
            "abaaaaa, abaaaab, abaaaba, abaaabb, abaabaa, abaabab, abaabba, abaabbb, ababaaa, ababaab, abababa, " +
            "abababb, ababbaa, ababbab, ababbba, ababbbb, abbaaaa, abbaaab, abbaaba, abbaabb, abbabaa, abbabab, " +
            "abbabba, abbabbb, abbbaaa, abbbaab, abbbaba, abbbabb, abbbbaa, abbbbab, abbbbba, bbaaaaa, bbaaaab, " +
            "bbaaaba, bbaaabb, bbaabaa, bbaabab, bbaabba, bbaabbb, bbabaaa, bbabaab, bbababa, bbababb, bbabbaa, " +
            "bbabbab, bbabbba, bbabbbb, bbbaaaa, bbbaaab, bbbaaba, bbbaabb, bbbabaa, bbbabab, bbbabba, bbbabbb, " +
            "bbbbaaa, bbbbaab, bbbbaba, bbbbabb, bbbbbaa, bbbbbab, bbbbbba, bbbbbbb, babaaaa, babaaab, babaaba, " +
            "babaabb, bababaa, bababab, bababba, bababbb, babbaaa, babbaab, babbaba, babbabb, babbbaa, babbbab, " +
            "babbbba, babbbbb, baabaaa, baabaab, baababa, baababb, baabbaa, baabbab, baabbba, baabbbb, baaabaa, " +
            "baaabab, baaabba, baaabbb, baaaaba, baaaabb, baaaaab")]
        public void Test2(int length, string expectedString)
        {
            //arrange
            List<int> states = new List<int>() { 1, 2, 3, 4 };
            int startState = 1;
            List<int> finalStates = new List<int>() { 4 };
            List<TransitionDTO> transitions = new List<TransitionDTO>()
            {
                new TransitionDTO(1, 'a', 2),
                new TransitionDTO(1, 'b', 3),
                new TransitionDTO(2, 'a', 4),
                new TransitionDTO(2, 'b', 2),
                new TransitionDTO(3, 'b', 4),
                new TransitionDTO(3, 'a', 3),
                new TransitionDTO(4, 'a', 4),
                new TransitionDTO(4, 'b', 4)
            };
            AutomatDTO automat = new AutomatDTO(states, transitions, startState, finalStates);

            //act
            string res = _worker.GetResult(automat, length);

            //assert
            Assert.AreEqual(res, expectedString);
        }

        [Test]
        [TestCase(3, "aab, aba, bbb, bab")]
        [TestCase(6, "aaaaaa, aaaabb, aaabab, aaabba, aabaab, aababa, aabbaa, aabbbb, " +
            "abaaab, abaaba, ababaa, ababbb, abbaaa, abbabb, abbbab, abbbba, bbaaaa, " +
            "bbaabb, bbabab, bbabba, bbbaab, bbbaba, bbbbaa, bbbbbb, babaab, bababa, " +
            "babbaa, babbbb, baabaa, baabbb, baaabb, baaaab")]
        public void Test3(int length, string expectedString)
        {
            //arrange
            List<int> states = new List<int>() { 1, 2, 3, 4 };
            int startState = 1;
            List<int> finalStates = new List<int>() { 4 };
            List<TransitionDTO> transitions = new List<TransitionDTO>()
            {
                new TransitionDTO(1, 'a', 2),
                new TransitionDTO(1, 'b', 3),
                new TransitionDTO(2, 'a', 4),
                new TransitionDTO(2, 'b', 2),
                new TransitionDTO(3, 'b', 4),
                new TransitionDTO(3, 'a', 3),
                new TransitionDTO(4, 'a', 2),
                new TransitionDTO(4, 'b', 4),

            };
            AutomatDTO automat = new AutomatDTO(states, transitions, startState, finalStates);

            //act
            string res = _worker.GetResult(automat, length);

            //assert
            Assert.AreEqual(res, expectedString);
        }
    }
}