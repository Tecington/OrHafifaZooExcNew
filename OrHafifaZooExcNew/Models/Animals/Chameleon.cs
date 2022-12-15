using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.Enums;

namespace OrHafifaZooExcNew.Models.Animals
{
    internal class Chameleon : Lizard
    {
        public Color CurrentColor { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(CurrentColor)}", CurrentColor);
            basicDictionary["type"] = $"{this.GetType().Name}";

            return basicDictionary;
        }
    }
}