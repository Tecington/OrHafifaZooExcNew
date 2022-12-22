namespace Zoo.Models.FileWriters
{
    internal static class FileWriter
    {
        internal static void WriteDataToFile(string path, string data)
        {
            Console.WriteLine(data);
            File.WriteAllText(path, data);
        }
    }
}