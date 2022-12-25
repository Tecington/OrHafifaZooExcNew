using Zoo.Models.AnimalFamilies;
using Zoo.Models.CustomAttributes;

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