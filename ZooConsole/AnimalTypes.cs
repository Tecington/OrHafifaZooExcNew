using Zoo.Models.Animals;
using Zoo.Models.Animals.Otters;

namespace ZooConsole
{
    internal static class AnimalTypes
    {
        public static readonly List<Type> Types = new()
        {
            typeof(Otter),
            typeof(Chameleon),
            typeof(Elephant),
            typeof(Ostrich),
            typeof(Shark),
            typeof(Tiger)
        };
    }
}
