using OrHafifaZooExcNew.AnimalFamilies;
using OrHafifaZooExcNew.Enums;

namespace OrHafifaZooExcNew.Animals
{
    internal class Shark : Fish
    {
        public SharkType Type { get; set; }
        public bool IsLawyer { get; set; }

        public override Dictionary<string, object> GetProperties()
        {
            var basicDictionary = base.GetProperties();

            basicDictionary.Add($"{nameof(IsLawyer)}", IsLawyer);
            basicDictionary.Add($"{nameof(Type)}", Type);
            basicDictionary["type"] = $"{this.GetType().Name}";

            return basicDictionary;
        }
    }
}