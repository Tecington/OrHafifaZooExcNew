using System.Configuration;
using Zoo.Exceptions;
using Zoo.Models.FileWriters;
using Zoo.Models.Serializers;

namespace Zoo
{
    public class ZooManager
    {
        private readonly string CsvFilePath = ConfigurationManager.AppSettings["CsvFilePath2"];
        private readonly string JsonFilePath = ConfigurationManager.AppSettings["JsonFilePath2"];
        private readonly string SaveType = ConfigurationManager.AppSettings["SaveFileType"];

        public void SaveZoo(IEnumerable<object> animals)
        {
            switch (SaveType)
            {
                case "Json":
                    MigrateZooToJson(animals);

                    break;
                case "Csv":
                    MigrateZooToCsv(animals);

                    break;
                case null:
                    throw new NoSaveTypeChosenException();
                default:
                    throw new InvalidSaveTypeException();
            }
        }

        private void MigrateZooToJson(IEnumerable<object> animals)
        {
            var data = new JsonSerializer().Serialize(animals);

            MigrateZoo(data, JsonFilePath);
        }

        private void MigrateZooToCsv(IEnumerable<object> animals)
        {
            var data = new CsvSerializer().Serialize(animals);

            MigrateZoo(data, CsvFilePath);
        }

        private void MigrateZoo(string data, string filePath)
        {
            try
            {
                FileWriter.WriteDataToFile(filePath, data);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong writing to file");
            }
        }
    }
}