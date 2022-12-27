namespace Zoo.Models.Animals.Birds.Species
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