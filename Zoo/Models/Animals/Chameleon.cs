using Zoo.Models.Animals.AnimalFamilies;
using Zoo.Models.Attributes;
using Zoo.Models.Enums;

namespace Zoo.Models.Animals
{
    [Animal]
    public class Chameleon : Lizard
    {
        public Color CurrentColor { get; set; }

        public Chameleon()
        {
            Type = GetType().Name;
        }
    }
}