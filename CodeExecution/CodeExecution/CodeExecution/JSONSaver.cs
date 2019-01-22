using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CodeExecution
{
    public static class JSONSaver
    {
        public static void SaveQuestions(List<Topic> questions)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Topic>));

            using (FileStream fs = new FileStream("questions.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, questions);
            }
        }

        public static List<Topic> LoadQuestions()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Topic>));

            using (FileStream fs = new FileStream("questions.json", FileMode.OpenOrCreate))
            {
               var questions = (List<Topic>)jsonFormatter.ReadObject(fs);

                return questions;
            }
        }
    }
}
