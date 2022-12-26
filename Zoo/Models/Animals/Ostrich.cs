using Zoo.Models.Attributes;
using Zoo.Models.Animals.AnimalFamilies;

namespace Zoo.Models.Animals
{
    [Animal]
    public class Ostrich : Bird
    {
        public bool IsHeadInGround { get; set; }

        public Ostrich()
        {
            Type = GetType().Name;
        }
    }
}