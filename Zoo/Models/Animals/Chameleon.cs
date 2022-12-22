using Zoo.Models.AnimalFamilies;
using Zoo.Models.Enums;

namespace Zoo.Models.Animals
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