using OrHafifaZooExcNew.Models.AnimalFamilies;
using OrHafifaZooExcNew.Models.CustomAttributes;
using OrHafifaZooExcNew.Models.Enums;

namespace OrHafifaZooExcNew.Models.Animals
{
    [IsSerializable(false)]
    internal class Shark : Fish
    {
        public SharkType SharkType { get; set; }
        public bool IsLawyer { get; set; }

        public Shark()
        {
            Type = GetType().Name;
        }
    }
}