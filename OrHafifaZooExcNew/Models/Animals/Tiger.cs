using OrHafifaZooExcNew.Models.AnimalFamilies;

namespace OrHafifaZooExcNew.Models.Animals
{
    internal class Tiger : Mammal
    {
        public int Stripes { get; set; }
        public int HumansEaten { get; set; }

        public Tiger()
        {
            Type = GetType().Name;
        }
    }
}