using OrHafifaZooExcNew.Serializers;
using OrHafifaZooExcNew.Models.Interfaces;
using OrHafifaZooExcNew.Models.FileWriters;

namespace OrHafifaZooExcNew.Zoo
{
    internal class ZooManager
    {
        private const string CsvFileEndPath = "\\testCSVfile.csv";
        private const string JsonFileEndPath = "\\testJsonFile.json";
        private readonly string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public void MigrateZooToJson(IEnumerable<ISerializableObject> animals)
        {
            var data = new JsonSerializer().Serialize(animals);

            MigrateZoo(data, _desktopPath + JsonFileEndPath);
        }

        public void MigrateZooToCsv(IEnumerable<ISerializableObject> animals)
        {
            var data = new CsvSerializer().Serialize(animals);

            MigrateZoo(data, _desktopPath + CsvFileEndPath);
        }

        public static void MigrateZoo(string data, string filePath)
        {
            try
            {
                FileWriter.WriteDataToFile(filePath, data);
            }
            catch (Exception)
            {
                ConsoleIo.WriteToConsole("Exception caught writing to file");
            }
        }
    }
}