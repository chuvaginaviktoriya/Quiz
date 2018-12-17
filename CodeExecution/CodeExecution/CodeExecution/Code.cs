using System;
using System.CodeDom.Compiler;

namespace CodeExecution
{
    public class Code
    {
        private string _typeName = "Execution"; 
        private string _methodName = "Main";
        private CompilerResults _compilerResults;

        public Code(CompilerResults compilerResults)
        {
            _compilerResults = compilerResults;
        }

        public string GetSolution(object[] parameters)
        {
            var assembly = _compilerResults.CompiledAssembly;
            var type = assembly.GetType(_typeName);
            var method = type.GetMethod(_methodName);
            string result = "";

            try
            {
                result += method.Invoke(null, parameters).ToString();
            }
            catch (Exception e)
            {
                result += e.Message;
            }

            return result;
        }
    }
}
