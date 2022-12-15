using System.Configuration;
using OrHafifaZooExcNew.Models.FileWriters;
using OrHafifaZooExcNew.Models.Serializers;
using OrHafifaZooExcNew.Properties;

namespace OrHafifaZooExcNew.Zoo
{
    internal class ZooManager
    {
        private readonly string CsvFilePath = ConfigurationManager.AppSettings["CsvFilePath"];
        private readonly string JsonFilePath = ConfigurationManager.AppSettings["JsonFilePath"];

        public void MigrateZooToJson(IEnumerable<object> animals)
        {
            var data = new JsonSerializer().Serialize(animals);

            MigrateZoo(data, JsonFilePath);
        }

        public void MigrateZooToCsv(IEnumerable<object> animals)
        {
            var data = new CsvSerializer().Serialize(animals);

            MigrateZoo(data, CsvFilePath);
        }

        public static void MigrateZoo(string data, string filePath)
        {
            try
            {
                FileWriter.WriteDataToFile(filePath, data);
            }
            catch (Exception)
            {
                ConsoleIo.WriteToConsole(Resources.WritingToFileExceptionMessage);
            }
        }
    }
}