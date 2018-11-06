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
                var assembly = results.CompiledAssembly;
                var evaluatorType = assembly.GetType(_typeName);
                var evaluator = Activator.CreateInstance(evaluatorType);

                output = InvokeMethod(evaluatorType, _methodName, evaluator, input).ToString();
                return output;
            }

            output = Environment.NewLine + "Problems at compile time!";
            return results.Errors.Cast<CompilerError>().Aggregate(output, (current, ce) => current + string.Format(Environment.NewLine + "line{0}: {1}", ce.Line, ce.ErrorText));
        }

        private object InvokeMethod(Type evaluatorType, string methodName, object evaluator, object[] methodParams)
        {
            return evaluatorType.InvokeMember(methodName, System.Reflection.BindingFlags.InvokeMethod, null, evaluator, methodParams);
        }
    }
}
