using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeExecution
{
    public static class BinarySaver
    {

        public static void SaveToBinnary(List<Topic> serializableObjects)
        {
            using (FileStream fs = File.Create("questions"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, serializableObjects);
            }
        }

        public static List<Topic> LoadFromBinnary()
        {
            if (File.Exists("questions"))
            {
                using (FileStream fs = File.Open("questions", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (List<Topic>)formatter.Deserialize(fs);
                }
            }
            return new List<Topic>();
        }

    }
}
