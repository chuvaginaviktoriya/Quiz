using System.Collections.Generic;
using System;

namespace CodeExecution
{
    [Serializable]
    public class Statement
    {
        public List<string> Text { get; private set; }
        public List<Limit> Limits { get; private set; } 

        public Statement(List<string> text, List<Limit> limits)
        {
            Text = text;
            Limits = limits;          
        }
    }
}
