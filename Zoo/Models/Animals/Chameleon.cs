using Zoo.Models.AnimalFamilies;
using Zoo.Models.CustomAttributes;
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