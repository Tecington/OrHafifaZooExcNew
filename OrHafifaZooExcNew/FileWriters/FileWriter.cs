using OrHafifaZooExcNew.Interfaces;
using OrHafifaZooExcNew.Serializers;

namespace OrHafifaZooExcNew.FileWriters
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