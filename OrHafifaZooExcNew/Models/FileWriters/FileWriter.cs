namespace OrHafifaZooExcNew.Models.FileWriters
{
    internal static class FileWriter
    {
        internal static void WriteDataToFile(string path, string data)
        {
            ConsoleIo.WriteToConsole(data);
            File.WriteAllText(path, data);
        }
    }
}