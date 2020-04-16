using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Interfaces
{
    public interface ILab1_BL
    {
        Task<string> GetResult_Part1Async(string input);
        string GetResult_Part1(string input);

        Task<string> GetResult_Part2Async(string input);
        string GetResult_Part2(string input);
    }
}
