using Zoo.Models.Animals.AnimalFamilies;
using Zoo.Models.Attributes;

namespace Zoo.Models.Animals
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