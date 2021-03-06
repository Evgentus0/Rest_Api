﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingParadigms_BLL.DTO
{
    public class GrammarDTO
    {
        public IEnumerable<string> NonTerminals { get; set; }
        public IEnumerable<string> Terminals { get; set; } 
        public IEnumerable<RuleDTO> Rules { get; set; }
    }

    public class RuleDTO
    {
        public string LeftPart { get; set; }
        public string RightPart { get; set; }

        public override string ToString()
        {
            return $"{LeftPart} -> {RightPart}";
        }
    }
}
