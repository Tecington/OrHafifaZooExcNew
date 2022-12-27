namespace Zoo.Models.Animals.Mammals.Species
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