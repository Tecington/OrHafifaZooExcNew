using Zoo.Models;
using Zoo.Models.Animals;
using Zoo.Models.Animals.AnimalFamilies.Birds.Species;
using Zoo.Models.Animals.AnimalFamilies.Fish.Species;
using Zoo.Models.Animals.AnimalFamilies.Lizards.Species;
using Zoo.Models.Animals.AnimalFamilies.Mammals.Species;
using Zoo.Models.Animals.Fish.Species.Sharks;
using Zoo.Models.Enums;

namespace ZooConsole.Data
{
    internal static class OrsZoo
    {
        public static readonly List<Animal> Animals = new()
        {
            new Chameleon
            {
                Age = 12,
                CurrentColor = AnimalColor.Blue,
                FavoriteHumanName = "Liron",
                Gender = AnimalGender.Female,
                Name = "Lizi"
            },
            new Elephant
            {
                Age = 100,
                FavoriteHumanName = "Piron",
                Gender = AnimalGender.Male,
                Name = "Pili",
                TrunkLength = 10,
                Tusks = 1
            },
            new Ostrich
            {
                Age = 40,
                FavoriteHumanName = "Shawn",
                Gender = AnimalGender.Male,
                IsHeadInGround = true,
                Name = "Osti"
            },
            new Otter
            {
                Age = 10,
                FavoriteHumanName = "Mike",
                Gender = AnimalGender.Female,
                Name = "Moshe",
                FavoriteRock = new Rock
                {
                    Weight = 3
                }
            },
            new Shark
            {
                Age = 30,
                FavoriteHumanName = "Amit",
                Gender = AnimalGender.Male,
                Name = "Amnon",
                IsLawyer = true,
                SharkType = SharkType.HammerHead
            },
            new Tiger
            {
                Age = 23,
                FavoriteHumanName = "Tom",
                Gender = AnimalGender.Female,
                HumansEaten = 3,
                Name = "Tigi",
                Stripes = 50
            }
        };
    }
}