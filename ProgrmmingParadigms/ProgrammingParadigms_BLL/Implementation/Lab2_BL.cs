using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Implementation
{
    public class Lab2_BL : ILab2_BL
    {
        public async Task<string> GetResultAsync(string input)
        {
            return await Task.Run(() => GetResult(input));
        }

        public string GetResult(string input)
        {
            var list = FindResult(input);

            string result = string.Empty;

            foreach (var elem in list)
            {
                result += $"{elem}; ";
            }
            return result;
        }

        private List<ValueIndex> FindResult(string input)
        {
            var list = GetList(input);

            var result = list.Where(x => IsLocalMin(x, list)).ToList();
            return result;
        }

        private List<ValueIndex> GetList(string data)
        {
            string input = data;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is empty!");
            }

            var numbers = input.Split(',', ';').Where(x => !string.IsNullOrEmpty(x));

            if (numbers.All(x => int.TryParse(x, out int res)))
            {
                List<ValueIndex> list = new List<ValueIndex>();
                for (int i = 0; i < numbers.Count(); i++)
                {
                    list.Add(new ValueIndex(int.Parse(numbers.ElementAt(i)), i));
                }

                return list;
            }
            else
            {
                throw new ArgumentException("Incorrect input numbers!");
            }
        }

        private bool IsLocalMin(ValueIndex element, List<ValueIndex> list)
        {
            if (element.index == 0)
            {
                if(element.value < list[element.index + 1].value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (element.index == list.Count - 1)
            {
                if (element.value < list[element.index - 1].value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if(element.value < list[element.index - 1].value
                    && element.value < list[element.index + 1].value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private struct ValueIndex
        {
            public int value;
            public int index;

            public ValueIndex(int value, int index)
            {
                this.value = value;
                this.index = index;
            }

            public override string ToString()
            {
                return $"({value} : {index})";
            }
        }
    }
}
