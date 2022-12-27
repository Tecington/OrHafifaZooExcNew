namespace Zoo.Models.Animals.AnimalFamilies.Birds.Species
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