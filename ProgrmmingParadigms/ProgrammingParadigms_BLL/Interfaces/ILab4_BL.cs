using ProgrammingParadigms_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Interfaces
{
    public interface ILab4_BL
    {
        bool CheckForLL1(GrammarDTO grammar);
        Task<bool> CheckForLL1Async(GrammarDTO grammar);

        (string first, string follow, bool isLL1) CheckForLL1WithDetails(GrammarDTO grammar);
        Task<(string first, string follow, bool isLL1)> CheckForLL1WithDetailsAsync(GrammarDTO grammar);
    }
}
