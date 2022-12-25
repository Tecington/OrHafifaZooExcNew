using Zoo.Models.CustomAttributes;
using Zoo.Models.AnimalFamilies;

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