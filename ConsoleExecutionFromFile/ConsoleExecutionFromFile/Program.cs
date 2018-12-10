using System;
using System.IO;
using CodeExecution;

namespace ConsoleExecutionFromFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currentDirrectory = Directory.GetCurrentDirectory();
            string[] paths = Directory.GetFiles(currentDirrectory + "\\Examples");

            foreach (var path in paths)
                if (path.IndexOf(".txt") != -1)
                {
                    ExecuteFromFile(path);
                } 
        }

        private static void ExecuteFromFile(string path)
        {
            string sourceCode;
            
            using (StreamReader sr = new StreamReader(path))
            {
                sourceCode = sr.ReadToEnd();
            }

            var limit = new Limit(7, 100);
            var limits = new Limit[] {limit};

            var question = new Question(sourceCode, limits);
            question.GenerateInputs();
            question.Solve();

            Console.WriteLine(sourceCode);
            Console.WriteLine("Input data: " + question.InputData[0]);
            Console.WriteLine("Answer: " + question.Answer);

            Console.ReadLine();
        }
    }
}
