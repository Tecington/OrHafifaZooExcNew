using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.CustomAttributes;

namespace OrHafifaZooExcNew.Models.Animals.Otters
{
    [IsSerializable(true)]
    internal class Otter : Mammal
    {
        public Rock FavoriteRock { get; set; }
    }
}