using Zoo.Models.AnimalFamilies;

namespace Zoo.Models.Animals
{
    public class Ostrich : Bird
    {
        public bool IsHeadInGround { get; set; }

        public Ostrich()
        {
            Type = GetType().Name;
        }
    }
}