using OrHafifaZooExcNew.Models.AnimalFamilies;

namespace OrHafifaZooExcNew.Models.Animals
{
    internal class Ostrich : Bird
    {
        public bool IsHeadInGround { get; set; }

        public Ostrich()
        {
            Type = GetType().Name;
        }
    }
}