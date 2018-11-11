using System;
using System.CodeDom.Compiler;
using System.Linq;

namespace CodeExecution
{
    public class Code
    {
        private string _typeName;
        private string _methodName;
        private string _sourceCode;

        public Code(string typeName, string methodName, string sourceCode)
        {
            _typeName = typeName;
            _methodName = methodName;
            _sourceCode = sourceCode;
        }

        public string GetSolution(object[] input)
        {
            string output;
            var compiler = CodeDomProvider.CreateProvider("CSharp");
            var parameters = new CompilerParameters
            {
                CompilerOptions = "/t:library",
                GenerateInMemory = true,
                IncludeDebugInformation = true
            };
            var results = compiler.CompileAssemblyFromSource(parameters, _sourceCode);

            if (!results.Errors.HasErrors)
            {
                output = InvokeMethod(results, input).ToString();
                return output;
            }

            output = Environment.NewLine + "Problems at compile time!";
            return results.Errors.Cast<CompilerError>().Aggregate(output, (current, ce) => current + string.Format(Environment.NewLine + "line{0}: {1}", ce.Line, ce.ErrorText));
        }

        private object InvokeMethod(CompilerResults results, object [] input)
        {
            var assembly = results.CompiledAssembly;
            var evaluatorType = assembly.GetType(_typeName);
            var evaluator = Activator.CreateInstance(evaluatorType);
            return evaluatorType.InvokeMember(_methodName, System.Reflection.BindingFlags.InvokeMethod, null, evaluator, input);
        }
    }
}
