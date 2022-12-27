namespace Zoo.Models.Animals.Mammals.Species
{
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