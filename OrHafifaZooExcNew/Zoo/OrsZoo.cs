using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.Animals;
using OrHafifaZooExcNew.Models.Animals.Otters;
using OrHafifaZooExcNew.Models.Enums;

namespace OrHafifaZooExcNew.Zoo
{
    internal static class OrsZoo
    {
        public static readonly List<Animal> Animals = new()
        {
            new Chameleon
            {
                Age = 12,
                CurrentColor = Color.Blue,
                FavoriteHumanName = "Liron",
                Gender = Gender.Female,
                Name = "Lizi"
            },
            new Elephant
            {
                Age = 100,
                FavoriteHumanName = "Piron",
                Gender = Gender.Male,
                Name = "Pili",
                TrunkLength = 10,
                Tusks = 1
            },
            new Ostrich
            {
                Age = 40,
                FavoriteHumanName = "Shawn",
                Gender = Gender.Male,
                IsHeadInGround = true,
                Name = "Osti"
            },
            new Otter
            {
                Age = 10,
                FavoriteHumanName = "Mike",
                Gender = Gender.Female,
                Name = "Moshe",
                FavoriteRock = new Rock()
                {
                    Weight = 3
                }
            },
            new Shark
            {
                Age = 30,
                FavoriteHumanName = "Amit",
                Gender = Gender.Male,
                Name = "Amnon",
                IsLawyer = true,
                SharkType = SharkType.HammerHead
            },
            new Tiger
            {
                Age = 23,
                FavoriteHumanName = "Tom",
                Gender = Gender.Female,
                HumansEaten = 3,
                Name = "Tigi",
                Stripes = 50
            }
        };
    }
}