using Zoo.Models.AnimalFamilies;

namespace Zoo.Models.Animals.Otters
{
    public class Otter : Mammal
    {
        public Rock FavoriteRock { get; set; }

        public Otter()
        {
            Type = GetType().Name;
        }
    }
}