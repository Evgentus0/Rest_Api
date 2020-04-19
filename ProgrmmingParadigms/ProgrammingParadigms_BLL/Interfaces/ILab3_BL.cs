using ProgrammingParadigms_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Interfaces
{
    public interface ILab3_BL
    {
        string GetResult(AutomatDTO automat, int length);
        Task<string> GetResultAsync(AutomatDTO automat, int length);
    }
}
