using Zoo.Models.AnimalFamilies;
using Zoo.Models.Enums;
using Zoo.Models.Animals;
using Color = Zoo.Models.Enums.Color;
using Zoo.Models.Animals.Otters;
using ZooConsole.Enums;

namespace ZooConsole;

internal class Program
{
    private static void Main()
    {
        //var animals = new List<Animal>
        //{
        //    new Otter
        //    {
        //        Age = 10,
        //        FavoriteHumanName = "Mike",
        //        Gender = Gender.Female,
        //        Name = "Moshe",
        //        FavoriteRock = new Rock
        //        {
        //            Weight = 3
        //        }
        //    }
        //};


        var app = new ZooConsoleApp();

        app.Start();
    }
}