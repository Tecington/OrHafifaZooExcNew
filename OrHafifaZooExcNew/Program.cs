using OrHafifaZooExcNew.Zoo;

namespace OrHafifaZooExcNew;

internal class Program
{
    private static void Main()
    {
       var zoo = new ZooManager();

       zoo.MigrateZooToCsv(ZooExample.Animals);
       zoo.MigrateZooToJson(ZooExample.Animals);
    }
}