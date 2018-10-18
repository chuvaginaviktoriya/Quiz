using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CompileDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string EvalCode(string typeName, string methodName, string sourceCode, int input)
        {
            
            string output;
            var compiler = CodeDomProvider.CreateProvider("CSharp");
            var parameters = new CompilerParameters
            {
                CompilerOptions = "/t:library",
                GenerateInMemory = true,
                IncludeDebugInformation = true
            };
            var results = compiler.CompileAssemblyFromSource(parameters, sourceCode);

            if (!results.Errors.HasErrors)
            {
                var assembly = results.CompiledAssembly;
                var evaluatorType = assembly.GetType(typeName);
                var evaluator = Activator.CreateInstance(evaluatorType);

                output = (string)InvokeMethod(evaluatorType, methodName, evaluator, new object[] { input });
                return output;
            }

            output = Environment.NewLine +"Problems at compile time!";
            return results.Errors.Cast<CompilerError>().Aggregate(output, (current, ce) => current + string.Format(Environment.NewLine + "line{0}: {1}", ce.Line, ce.ErrorText));
        }

        private object InvokeMethod(Type evaluatorType, string methodName, object evaluator, object[] methodParams)
        {
            return evaluatorType.InvokeMember(methodName, System.Reflection.BindingFlags.InvokeMethod, null, evaluator, methodParams);
        }

        private void Start_Click(object sender, EventArgs e)
        {

            int from = (int)From.Value;
            int to = (int)To.Value;
            Random rnd = new Random();
            int input = rnd.Next(to) - from;
            Result.Text = input.ToString()+ Environment.NewLine;
           Result.Text += EvalCode(Class.Text, Method.Text, Code.Text, input);
        }
    }
}
