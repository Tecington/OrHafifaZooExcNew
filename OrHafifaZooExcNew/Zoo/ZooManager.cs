﻿using System.Configuration;
using OrHafifaZooExcNew.Exceptions;
using OrHafifaZooExcNew.Models.FileWriters;
using OrHafifaZooExcNew.Models.Serializers;

namespace OrHafifaZooExcNew.Zoo
{
    public class ZooManager
    {
        private readonly string CsvFilePath = ConfigurationManager.AppSettings["CsvFilePath2"];
        private readonly string JsonFilePath = ConfigurationManager.AppSettings["JsonFilePath2"];

        public void SaveZoo(IEnumerable<object> animals)
        {
            var saveType = ConfigurationManager.AppSettings["SaveFileType"];

            if (saveType is null)
            {
                throw new NoSaveTypeChosenException();
            } else if (saveType.Equals("Json"))
            {
                MigrateZooToJson(animals);
            } else if (saveType.Equals("Csv"))
            {
                MigrateZooToCsv(animals);
            }
            else
            {
                throw new InvalidSaveTypeException();
            }
        }

        internal void MigrateZooToJson(IEnumerable<object> animals)
        {
            var data = new JsonSerializer().Serialize(animals);

            MigrateZoo(data, JsonFilePath);
        }

        internal void MigrateZooToCsv(IEnumerable<object> animals)
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