using OrHafifaZooExcNew.AnimalFamilies;

namespace OrHafifaZooExcNew.Animals
{
    internal class Tiger : Mammal
    {
        public int Stripes { get; set; }
        public int HumansEaten { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(Stripes)}", Stripes);
            basicDictionary.Add($"{nameof(HumansEaten)}", HumansEaten);
            basicDictionary["type"] = $"{this.GetType().Name}";

            return basicDictionary;
        }
    }
}