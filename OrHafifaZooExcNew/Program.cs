using OrHafifaZooExcNew.Zoo;

namespace OrHafifaZooExcNew;

internal class Program
{
    private static void Main()
    {
       var zoo = new ZooManager();

       zoo.MigrateZooToCsv(OrsZoo.Animals);
       zoo.MigrateZooToJson(OrsZoo.Animals);
    }
}