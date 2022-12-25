using Zoo.Models.AnimalFamilies;
using Zoo.Models.CustomAttributes;

namespace Zoo.Models.Animals
{
    [Animal]
    public class Tiger : Mammal
    {
        public int Stripes { get; set; }
        public int HumansEaten { get; set; }

        public Tiger()
        {
            Type = GetType().Name;
        }
    }
}