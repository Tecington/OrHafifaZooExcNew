using OrHafifaZooExcNew.Models.CustomAttributes;

namespace OrHafifaZooExcNew.Models.Animals.Otters
{
    [IsSerializable(true)]
    internal class Rock
    {
        public int Weight { get; set; }
    }
}