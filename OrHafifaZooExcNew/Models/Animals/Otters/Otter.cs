using OrHafifaZooExcNew.Models.AnimalFamilies;

namespace OrHafifaZooExcNew.Models.Animals.Otters
{
    internal class Otter : Mammal
    {
        public Rock FavoriteRock { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(FavoriteRock)}", FavoriteRock);
            basicDictionary["type"] = $"{GetType().Name}";

            return basicDictionary;
        }
    }
}