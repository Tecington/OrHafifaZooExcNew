using Zoo.Models.AnimalFamilies;
using Zoo.Models.CustomAttributes;

namespace Zoo.Models.Animals.Otters
{
    [Animal]
    public class Otter : Mammal
    {
        public Rock FavoriteRock { get; set; }

        public Otter()
        {
            Type = GetType().Name;
        }
    }
}