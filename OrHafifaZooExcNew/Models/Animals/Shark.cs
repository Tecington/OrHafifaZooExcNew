using OrHafifaZooExcNew.Enums;
using OrHafifaZooExcNew.Models.AnimalFamilies;

namespace OrHafifaZooExcNew.Models.Animals
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
            basicDictionary["type"] = $"{GetType().Name}";

            return basicDictionary;
        }
    }
}