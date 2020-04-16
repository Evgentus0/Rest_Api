using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Implementation
{
    public class Lab1_BL : ILab1_BL
    {
        public async Task<string> GetResult_Part1Async(string input)
        {
            return await Task.Run(() => GetResult_Part1(input));
        }
        public string GetResult_Part1(string input)
        {
            var list = FindResult_Part1(input);

            string result = string.Empty;

            foreach (var elem in list)
            {
                result += $"{elem}; ";
            }
            return result;
        }

        private List<int> FindResult_Part1(string input)
        {
            var list = GetList(input);

            var result = list.Where(x => FindEntries(x, list) == 3).ToList();
            return result;
        }

        private List<int> GetList(string data)
        {
            string input = data;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is empty!");
            }

            var numbers = input.Split(',', ';').Where(x => !string.IsNullOrWhiteSpace(x));

            if (numbers.All(x => int.TryParse(x, out int res)))
            {
                var list = numbers.Select(x => int.Parse(x)).ToList();

                return list;
            }
            else
            {
                throw new ArgumentException("Incorrect input numbers!");
            }
        }

        private int FindEntries(int elem, List<int> list)
        {
            return list.Where(x => x == elem).Count();
        }


        public async Task<string> GetResult_Part2Async(string input)
        {
            return await Task.Run(() => GetResult_Part2(input));
        }
        public string GetResult_Part2(string input)
        {
            var pairLists = FindResult_Part2(input);

            string result = string.Empty;

            foreach (var elem in pairLists.part1)
            {
                result += $"{elem}; ";
            }

            result += " | ";

            foreach (var elem in pairLists.part2)
            {
                result += $"{elem}; ";
            }
            return result;
        }

        private PairLists FindResult_Part2(string input)
        {
            var list = GetList(input);

            PairLists result = SeparateList(list);
            return result;
        }

        private PairLists SeparateList(List<int> list)
        {
            List<int> result1 = new List<int>();
            List<int> result2 = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    result1.Add(list[i]);
                }
                else
                {
                    result2.Add(list[i]);
                }
            }
            return new PairLists(result1, result2);
        }

        private struct PairLists
        {
            public List<int> part1;
            public List<int> part2;

            public PairLists(List<int> first, List<int> second)
            {
                part1 = first;
                part2 = second;
            }
        }
    }
}
