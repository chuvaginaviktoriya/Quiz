using System.CodeDom.Compiler;
using System.Linq;

namespace CodeExecution
{
    public static class CodeCreation
    {
        private static string _usings = @"using System.Collections.Generic;         
             using System;
             using System.IO;
             using System.Linq;
 ";
        public static int UsingsCount = _usings.Split('\n').Count() - 1;     

        public static bool TryCreateCode(string sourceCode, out Code code, out CompilerErrorCollection errors)
        {
            sourceCode = _usings + sourceCode;
            code = new Code(sourceCode);

            if (code.IsCodeValid(out errors)) return true;

            code = null;
            return false;
        }

    }
}
