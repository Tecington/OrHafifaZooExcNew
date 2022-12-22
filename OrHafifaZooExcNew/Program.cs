using OrHafifaZooExcNew.Models.CustomAttributes;
using OrHafifaZooExcNew.Zoo;
using System.Reflection;

namespace OrHafifaZooExcNew;

internal class Program
{
    private static void Main()
    {
       //var zoo = new ZooManager();

       //zoo.MigrateZooToCsv(OrsZoo.Animals);
       //zoo.MigrateZooToJson(OrsZoo.Animals);

       //Print(bloop.beep);

       var test = new testClass();

       if (test.GetType().GetCustomAttributes().OfType<IsSerializableAttribute>()
           .Select(attribute =>
               attribute.IsSerializable).FirstOrDefault())
       {
           Console.WriteLine("Serializingggg");
       }
    }

    private static void Print(Enum anEnum)
    {
        Console.WriteLine(anEnum);
    }
}

[IsSerializable(false)]
internal class testClass
{

}

internal enum bloop
{
    beep = 1,
    boing
}