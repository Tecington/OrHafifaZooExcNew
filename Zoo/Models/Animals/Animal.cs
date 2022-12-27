using Zoo.Attributes;
using Zoo.Enums;

namespace Zoo.Models.Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FavoriteHumanName { get; set; }
        [HidePrint]
        public string Type { get; set; }
    }
}