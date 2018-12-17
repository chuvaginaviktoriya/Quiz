using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;

namespace CodeExecution
{
    public static class CodeCreation
    {
        public static string LastErrors = "";

        private static string _usings = @"using System.Collections.Generic;         
             using System;
             using System.IO;
             using System.Linq;
             using System.Numerics;
 ";
        private static int _usingsCount = _usings.Split('\n').Count() - 1;
      

        public static bool TryCreateCode(string sourceCode, out Code code)
        {
            var compilerResults = CompileSourceCode(_usings + sourceCode);
            if (compilerResults.Errors.HasErrors)
            {
                code = null;
                LastErrors = GetErrorsList(compilerResults);
                return false;
            }

            code =new Code(compilerResults);
            return true;
        }

        private static CompilerResults CompileSourceCode(string sourceCode)
        {
            var compiler = new Microsoft.CSharp.CSharpCodeProvider();
            var parameters = GetParameters();

            return compiler.CompileAssemblyFromSource(parameters, sourceCode);
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

        private static string GetErrorsList(CompilerResults results)
        {
            var output = Environment.NewLine + "Problems at compile time!";
            var compilerErrorList = results.Errors.Cast<CompilerError>();

            foreach (var compilerError in compilerErrorList)
                output += string.Format(Environment.NewLine + "line{0}: {1}", compilerError.Line - _usingsCount, compilerError.ErrorText);

            return output;
        }

    }
}
