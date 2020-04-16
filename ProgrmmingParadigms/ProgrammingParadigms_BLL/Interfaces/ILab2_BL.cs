using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Interfaces
{
    public interface ILab2_BL
    {
        Task<string> GetResultAsync(string input);
        string GetResult(string input);
    }
}
