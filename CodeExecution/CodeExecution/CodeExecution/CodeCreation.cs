using System.CodeDom.Compiler;
using System.IO;
using System.Linq;

namespace CodeExecution
{
    public static class CodeCreation
    {
        private static string _usings = @"using System.Collections.Generic;         
             using System;
             using System.IO;
             using System.Linq;
             using System.Numerics;
 ";
        public static int UsingsCount = _usings.Split('\n').Count() - 1;     

        public static bool TryCreateCode(string sourceCode, out Code code, out CompilerErrorCollection errors)
        {
            sourceCode = _usings + sourceCode;
            var compilerParameters = GetParameters();
            code = new Code(sourceCode, compilerParameters);
            if (!code.IsCodeValid(out errors))
            {
                code = null;
                return false;
            }
            return true;
        }

        private static CompilerParameters GetParameters()
        {
            var parameters = new CompilerParameters()
            {
                IncludeDebugInformation = true
           
            };

            string currentDirrectory = Directory.GetCurrentDirectory();

            if (Directory.Exists(currentDirrectory + "\\Assemblies"))
            {
                string[] paths = Directory.GetFiles(currentDirrectory + "\\Assemblies");

                foreach (var path in paths)
                    if (path.IndexOf(".dll") != -1)
                        parameters.ReferencedAssemblies.Add(path);
            }

            return parameters;
        }

       

    }
}
