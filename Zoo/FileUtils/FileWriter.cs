namespace Zoo.FileUtils
{
    internal static class FileWriter
    {
        internal static void WriteData(string path, string data)
        {
            Console.WriteLine(data);
            File.WriteAllText(path, data);
        }
    }
}