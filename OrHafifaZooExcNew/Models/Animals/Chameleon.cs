using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.Enums;

namespace OrHafifaZooExcNew.Models.Animals
{
    internal class Chameleon : Lizard
    {
        public Color CurrentColor { get; set; }

        public Chameleon()
        {
            Type = GetType().Name;
        }
    }
}