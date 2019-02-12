using System.Collections.Generic;
using System;

namespace CodeExecution
{
    [Serializable]
    public class Statement
    {
        public List<string> Text { get; }
        public List<Limit> Limits { get; } 

        public Statement(List<string> text, List<Limit> limits)
        {
            Text = text;
            Limits = limits;          
        }
    }
}
