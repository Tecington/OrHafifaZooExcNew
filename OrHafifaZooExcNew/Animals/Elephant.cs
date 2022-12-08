using OrHafifaZooExcNew.AnimalFamilies;

namespace OrHafifaZooExcNew.Animals
{
    internal class Elephant : Mammal
    {
        public int TrunkLength { get; set; }
        public int Tusks { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(TrunkLength)}", TrunkLength);
            basicDictionary.Add($"{nameof(Tusks)}", Tusks);
            basicDictionary["type"] = $"{this.GetType().Name}";

            return basicDictionary;
        }
    }
}