using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;

namespace CodeExecution
{
    public class Code
    {
         private const string _usings = @"using System.Collections.Generic;         
             using System;
             using System.IO;
             using System.Linq;
             using System.Numerics;
 ";

        private int _usingsCount = _usings.Split('\n').Count() - 1;
        private string _typeName = "Execution"; 
        private string _methodName = "Main";
        private string _sourceCode;
        private CompilerResults _compilerResults;

        public Code(string sourceCode)
        {
            _sourceCode = _usings;
            _sourceCode += sourceCode;
            _compilerResults = CompileSourceCode();         
        }

        public string GetSolution(object[] input)
        {
            if (_compilerResults.Errors.HasErrors)
                return GetErrorsList(_compilerResults);

            return InvokeStaticMethod(input).ToString();
        }

        private CompilerResults CompileSourceCode()
        {
            var compiler = CodeDomProvider.CreateProvider("CSharp");
            var parameters = GetParameters();

            return compiler.CompileAssemblyFromSource(parameters, _sourceCode);
        }

        private CompilerParameters GetParameters()
        {         
            var parameters = new CompilerParameters()
            {
                IncludeDebugInformation = true
            };
            string currentDirrectory = Directory.GetCurrentDirectory();

            if (Directory.Exists(currentDirrectory + "\\Assemblies"))
            {
                string[] paths = Directory.GetFiles(currentDirrectory+"\\Assemblies");

                foreach (var path in paths)
                    if (path.IndexOf(".dll") != -1)
                    {
                        parameters.ReferencedAssemblies.Add(path);
                    }
            }

            return parameters;
        }
        

        private string GetErrorsList(CompilerResults results)
        {
            var output = Environment.NewLine + "Problems at compile time!";

            return results.Errors.Cast<CompilerError>().Aggregate(output, (current, ce) =>
            current + string.Format(Environment.NewLine + "line{0}: {1}", ce.Line - _usingsCount, ce.ErrorText));
        }

        public object InvokeStaticMethod(object[] parameters)
        {
            var assembly = _compilerResults.CompiledAssembly;
            var type = assembly.GetType(_typeName);
            var method = type.GetMethod(_methodName);

            return method.Invoke(null, parameters);
        }
    }
}
