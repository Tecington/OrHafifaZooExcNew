using OrHafifaZooExcNew.Models.Enums;

namespace OrHafifaZooExcNew.Models.AnimalFamilies
{
    internal abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FavoriteHumanName { get; set; }
        public string Type { get; set; }
    }
}