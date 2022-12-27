using Zoo.Enums;
using Zoo.Attributes;

namespace Zoo.Models.Animals.AnimalFamilies.Fish.Species
{
    [UnSerializable]
    public class Shark : Fish
    {
        public SharkType SharkType { get; set; }
        public bool IsLawyer { get; set; }

        public Shark()
        {
            Type = GetType().Name;
        }
    }
}