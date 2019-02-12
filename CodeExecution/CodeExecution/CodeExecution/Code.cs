using System;
using System.CodeDom.Compiler;
using System.IO;

namespace CodeExecution
{
    [Serializable]
    public class Code
    {
        private const string TypeName = "Execution";
        private const string MethodName = "Main";

        private CompilerParameters _compilerParameters;
        private readonly string _sourceCode;

        public Code(string sourceCode)
        {
            _sourceCode = sourceCode;
        }

        public bool IsCodeValid(out CompilerErrorCollection list)
        {
            list = null;
            var compilerResults = CompileSourceCode();
            
            if (!compilerResults.Errors.HasErrors)
                return true;

            list = compilerResults.Errors;
            return false;

        }

        private static CompilerParameters GetParameters()
        {
            var parameters = new CompilerParameters()
            {
                IncludeDebugInformation = true
            };

            var currentDirrectory = Directory.GetCurrentDirectory();

            if (Directory.Exists(currentDirrectory + "\\Assemblies"))
            {
                string[] paths = Directory.GetFiles(currentDirrectory + "\\Assemblies");

                foreach (var path in paths)
                    if (path.IndexOf(".dll") != -1)
                        parameters.ReferencedAssemblies.Add(path);
            }

            return parameters;
        }

        private CompilerResults CompileSourceCode()
        {
            _compilerParameters = GetParameters();
            var compiler = CodeDomProvider.CreateProvider("CSharp");
            return compiler.CompileAssemblyFromSource(_compilerParameters, _sourceCode);
        }

        public string GetSolution(object[] parameters)
        {
            var compilerResults = CompileSourceCode();
            var assembly = compilerResults.CompiledAssembly;
            var type = assembly.GetType(TypeName);
            var method = type.GetMethod(MethodName);

            var result = "";

            try
            {
                result += method?.Invoke(null, parameters).ToString();
            }
            catch (Exception e)
            {
                result += e.Message;
            }

            return result;
        }
    }
}
