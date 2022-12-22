using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.CustomAttributes;

namespace OrHafifaZooExcNew.Models.Animals
{
    [IsSerializable(true)]
    internal class Elephant : Mammal
    {
        public int TrunkLength { get; set; }
        public int Tusks { get; set; }

        public Elephant()
        {
            Type = GetType().Name;
        }
    }
}