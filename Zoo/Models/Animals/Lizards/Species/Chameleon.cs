using Zoo.Models.Enums;

namespace Zoo.Models.Animals.Lizards.Species
{
    public class Chameleon : Lizard
    {
        public AnimalColor CurrentColor { get; set; }

        public Chameleon()
        {
            Type = GetType().Name;
        }
    }
}