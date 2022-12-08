using OrHafifaZooExcNew.AnimalFamilies;
using OrHafifaZooExcNew.Enums;

namespace OrHafifaZooExcNew.Animals
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