using System;
using System.Collections.Generic;
using System.IO;
using CodeExecution;

namespace ConsoleExecutionFromFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currentDirrectory = Directory.GetCurrentDirectory();
            string[] paths = Directory.GetFiles(currentDirrectory + "\\Code");
            string[] texts = Directory.GetFiles(currentDirrectory + "\\Text");
            string[] limits = Directory.GetFiles(currentDirrectory + "\\Limits");

            for (int i=0; i<paths.Length; i++)            
                    ExecuteFromFile(paths[i], texts[i], limits[i]);
        }

        private static List<Limit> GetLimits(string path)
        {
            var result = new List<Limit>();
            string limit;
            using (StreamReader sr = new StreamReader(path))
            {
                limit = sr.ReadToEnd();
            }
            var limits = limit.Split();
            for (int i=0; i<limits.Length/2;i++)
            {
                result.Add(new Limit(int.Parse(limits[i * 2]), int.Parse(limits[i * 2 + 1])));
            }

            return result;
        }

        private static void ExecuteFromFile(string path, string textPath, string limitsPath)
        {
            string sourceCode;
            string text;

            using (StreamReader sr = new StreamReader(path))
            {
                sourceCode = sr.ReadToEnd();
            }

            using (StreamReader sr = new StreamReader(textPath))
            {
                text = sr.ReadToEnd();
            }

            var limits = GetLimits(limitsPath);         

            Question question;
            if (!QuastionCreation.TryCreateQuestion(sourceCode, text, limits, out question))
            {
                Console.WriteLine(CodeCreation.LastErrors);
                Console.ReadLine();

                return;
            }

            question.GenerateInputs();
            question.Solve();

            Console.WriteLine(sourceCode);
            Console.WriteLine("Statement: " + question.GetStatement());
            Console.WriteLine("Answer: " + question.Answer);

            Console.ReadLine();
        }
    }
}
