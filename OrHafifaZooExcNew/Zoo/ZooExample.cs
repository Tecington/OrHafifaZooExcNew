using OrHafifaZooExcNew.Animals;
using OrHafifaZooExcNew.Classes;
using OrHafifaZooExcNew.Enums;
using OrHafifaZooExcNew.Interfaces;

namespace OrHafifaZooExcNew.Zoo
{
    internal static class ZooExample
    {
        public static readonly List<ISerializableObject> Animals = new()
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
                Type = SharkType.HammerHead
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
