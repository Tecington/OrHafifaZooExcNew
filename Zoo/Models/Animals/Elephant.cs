using Zoo.Models.Animals.AnimalFamilies;
using Zoo.Models.Attributes;

namespace Zoo.Models.Animals
{
    [Animal]
    public class Elephant : Mammal
    {
        public int TrunkLength { get; set; }
        public int Tusks { get; set; }

        public Elephant()
        {
            Type = GetType().Name;
        }
    }
}