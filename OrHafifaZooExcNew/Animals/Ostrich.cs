using OrHafifaZooExcNew.AnimalFamilies;

namespace OrHafifaZooExcNew.Animals
{
    internal class Ostrich : Bird
    {
        public bool IsHeadInGround { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(IsHeadInGround)}", IsHeadInGround);
            basicDictionary["type"] = $"{this.GetType().Name}";

            return basicDictionary;
        }
    }
}