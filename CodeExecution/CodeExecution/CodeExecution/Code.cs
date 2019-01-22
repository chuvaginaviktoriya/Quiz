using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace CodeExecution
{
    [Serializable]
    public class Code
    {
        private string _typeName = "Execution";
        private string _methodName = "Main";
        private CompilerParameters _compilerParameters;
        private string _sourceCode;

        [NonSerialized]
        private System.Reflection.Assembly _assembly = null;

        public Code(string sourceCode, CompilerParameters parameters)
        {
            _sourceCode = sourceCode;
            _compilerParameters = parameters;
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

        private CompilerResults CompileSourceCode()
        {
            var compiler = new Microsoft.CSharp.CSharpCodeProvider();
            return compiler.CompileAssemblyFromSource(_compilerParameters, _sourceCode);
        }

        public string GetSolution(object[] parameters)
        {
            if (_assembly == null)
            {
                var compilerResults = CompileSourceCode();
                _assembly = compilerResults.CompiledAssembly;
            }
            var type = _assembly.GetType(_typeName);
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
