using Zoo.Enums;

namespace Zoo.Models.Animals.AnimalFamilies.Lizards.Species
{
    public class Chameleon : Lizard
    {
        public Color CurrentColor { get; set; }

        public Chameleon()
        {
            Type = GetType().Name;
        }
    }
}