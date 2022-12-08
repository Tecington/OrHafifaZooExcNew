using OrHafifaZooExcNew.AnimalFamilies;
using OrHafifaZooExcNew.Classes;

namespace OrHafifaZooExcNew.Animals
{
    internal class Otter : Mammal
    {
        public Rock FavoriteRock { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(FavoriteRock)}", FavoriteRock);
            basicDictionary["type"] = $"{this.GetType().Name}";

            return basicDictionary;
        }
    }
}