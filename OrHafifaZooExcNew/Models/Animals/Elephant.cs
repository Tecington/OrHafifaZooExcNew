using OrHafifaZooExcNew.Models.AnimalFamilies;

namespace OrHafifaZooExcNew.Models.Animals
{
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